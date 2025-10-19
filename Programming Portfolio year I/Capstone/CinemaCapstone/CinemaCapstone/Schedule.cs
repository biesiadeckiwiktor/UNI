using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Capstone
{
    public class Schedule
    {
        private List<Screening> _screenings;
        public DateTime Date { get; private set; }

        public Schedule(DateTime date)
        {
            Date = date.Date;
            _screenings = new List<Screening>();
        }

        public bool CanAddScreening(Screening newScreening)
        {
            if (newScreening.StartTime.Date != Date)
                return false;

            foreach (var existingScreening in _screenings)
            {
                if (newScreening.OverlapsWith(existingScreening))
                    return false;

                // Check turnaround time
                int requiredTurnaround = Math.Max(
                    newScreening.GetRequiredTurnaroundTime(),
                    existingScreening.GetRequiredTurnaroundTime()
                );

                if (Math.Abs((newScreening.StartTime - existingScreening.EndTime).TotalMinutes) < requiredTurnaround ||
                    Math.Abs((existingScreening.StartTime - newScreening.EndTime).TotalMinutes) < requiredTurnaround)
                    return false;
            }

            return true;
        }

        public void AddScreening(Screening screening)
        {
            if (!CanAddScreening(screening))
                throw new InvalidOperationException("Cannot add screening due to scheduling conflicts");

            _screenings.Add(screening);
            _screenings = _screenings.OrderBy(s => s.StartTime).ToList();
        }

        public void RemoveScreening(Screening screening)
        {
            _screenings.Remove(screening);
        }

        public List<Screening> GetScreenings()
        {
            return new List<Screening>(_screenings);
        }

        public void SaveToFile(string directory)
        {
            string fileName = $"schedule_{Date:yyyy-MM-dd}.fs";
            string filePath = Path.Combine(directory, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var screening in _screenings)
                {
                    writer.WriteLine($"[Screening:{screening.Movie.Title}%Screen:{screening.Screen.Name}%Start:{screening.StartTime:HH:mm}%End:{screening.EndTime:HH:mm}]");
                }
            }
        }

        public static Schedule LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Schedule file not found: {filePath}");

            string fileName = Path.GetFileNameWithoutExtension(filePath);
            if (!DateTime.TryParseExact(fileName.Replace("schedule_", ""), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                throw new FormatException("Invalid date format in filename");

            var schedule = new Schedule(date);
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || !line.StartsWith("[Screening:") || !line.EndsWith("]"))
                    continue;

                string content = line.Substring(11, line.Length - 12);
                string[] parts = content.Split('%');

                if (parts.Length != 4)
                    continue;

                string movieTitle = parts[0];
                string screenName = parts[1].Replace("Screen:", "");
                string startTimeStr = parts[2].Replace("Start:", "");
                string endTimeStr = parts[3].Replace("End:", "");

                if (!DateTime.TryParseExact(startTimeStr, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime startTime))
                    continue;

                startTime = date.Add(startTime.TimeOfDay);

                var movie = Movie.GetAllMovies().FirstOrDefault(m => m.Title == movieTitle);
                var screen = Screen.GetAllScreens().FirstOrDefault(s => s.Name == screenName);

                if (movie != null && screen != null)
                {
                    try
                    {
                        var screening = new Screening(movie, screen, startTime);
                        schedule.AddScreening(screening);
                    }
                    catch (InvalidOperationException)
                    {
                        // Skip invalid screenings
                        continue;
                    }
                }
            }

            return schedule;
        }
    }
} 