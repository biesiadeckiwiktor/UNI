using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Menus
{
    internal class ManageScheduleMenuItem : MenuItem
    {
        private ManagerMenu _parentMenu;
        private const string SCHEDULES_DIRECTORY = "Schedules";

        public ManageScheduleMenuItem(ManagerMenu parentMenu)
        {
            _parentMenu = parentMenu;
            if (!Directory.Exists(SCHEDULES_DIRECTORY))
            {
                Directory.CreateDirectory(SCHEDULES_DIRECTORY);
            }
        }

        public override void Select()
        {
            while (true)
            {
                Console.WriteLine("\nSchedule Management Menu");
                Console.WriteLine("1. Create New Schedule");
                Console.WriteLine("2. Add Screening to Schedule");
                Console.WriteLine("3. Remove Screening from Schedule");
                Console.WriteLine("4. View Schedule");
                Console.WriteLine("5. Save Schedule");
                Console.WriteLine("6. Load Schedule");
                Console.WriteLine("7. Return to Previous Menu");

                int choice = ConsoleHelpers.GetIntegerInRange(1, 7, "Select an option");

                switch (choice)
                {
                    case 1:
                        CreateNewSchedule();
                        break;
                    case 2:
                        AddScreeningToSchedule();
                        break;
                    case 3:
                        RemoveScreeningFromSchedule();
                        break;
                    case 4:
                        ViewSchedule();
                        break;
                    case 5:
                        SaveSchedule();
                        break;
                    case 6:
                        LoadSchedule();
                        break;
                    case 7:
                        return;
                }
            }
        }

        private void CreateNewSchedule()
        {
            Console.WriteLine("\nEnter date for new schedule (DD/MM/YYYY):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                var schedule = new Schedule(date);
                _parentMenu.GetManager().SetCurrentSchedule(schedule);
                Console.WriteLine($"New schedule created for {date:dd/MM/yyyy}");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use DD/MM/YYYY");
            }
        }

        private void AddScreeningToSchedule()
        {
            var manager = _parentMenu.GetManager();
            var schedule = manager.GetCurrentSchedule();
            if (schedule == null)
            {
                Console.WriteLine("No active schedule. Please create a schedule first.");
                return;
            }

            // Select movie
            var movies = Movie.GetAllMovies();
            int movieIndex = ConsoleHelpers.GetSelectionFromMenu(
                movies.ConvertAll(m => m.ToString()),
                "Select a movie"
            );
            if (movieIndex == -1) return;

            // Select screen
            var screens = Screen.GetAllScreens();
            int screenIndex = ConsoleHelpers.GetSelectionFromMenu(
                screens.ConvertAll(s => s.ToString()),
                "Select a screen"
            );
            if (screenIndex == -1) return;

            // Get start time
            Console.WriteLine("\nEnter start time (HH:mm):");
            if (DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime startTime))
            {
                startTime = schedule.Date.Add(startTime.TimeOfDay);
                var screening = new Screening(movies[movieIndex], screens[screenIndex], startTime);

                try
                {
                    manager.AddScreeningToSchedule(schedule, screening);
                    Console.WriteLine("Screening added successfully");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid time format. Please use HH:mm");
            }
        }

        private void RemoveScreeningFromSchedule()
        {
            var manager = _parentMenu.GetManager();
            var schedule = manager.GetCurrentSchedule();
            if (schedule == null)
            {
                Console.WriteLine("No active schedule. Please create a schedule first.");
                return;
            }

            var screenings = schedule.GetScreenings();
            if (screenings.Count == 0)
            {
                Console.WriteLine("No screenings in the current schedule.");
                return;
            }

            int screeningIndex = ConsoleHelpers.GetSelectionFromMenu(
                screenings.ConvertAll(s => s.ToString()),
                "Select a screening to remove"
            );
            if (screeningIndex == -1) return;

            manager.RemoveScreeningFromSchedule(schedule, screenings[screeningIndex]);
            Console.WriteLine("Screening removed successfully");
        }

        private void ViewSchedule()
        {
            var manager = _parentMenu.GetManager();
            var schedule = manager.GetCurrentSchedule();
            if (schedule == null)
            {
                Console.WriteLine("No active schedule. Please create a schedule first.");
                return;
            }

            Console.WriteLine($"\nSchedule for {schedule.Date:dd/MM/yyyy}:");
            var screenings = schedule.GetScreenings();
            if (screenings.Count == 0)
            {
                Console.WriteLine("No screenings scheduled");
            }
            else
            {
                foreach (var screening in screenings)
                {
                    Console.WriteLine(screening);
                }
            }
        }

        private void SaveSchedule()
        {
            var manager = _parentMenu.GetManager();
            var schedule = manager.GetCurrentSchedule();
            if (schedule == null)
            {
                Console.WriteLine("No active schedule to save.");
                return;
            }

            try
            {
                manager.SaveSchedule(schedule, SCHEDULES_DIRECTORY);
                Console.WriteLine("Schedule saved successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving schedule: {ex.Message}");
            }
        }

        private void LoadSchedule()
        {
            var manager = _parentMenu.GetManager();
            var availableFiles = manager.GetAvailableScheduleFiles(SCHEDULES_DIRECTORY);
            if (availableFiles.Count == 0)
            {
                Console.WriteLine("No schedule files available.");
                return;
            }

            int fileIndex = ConsoleHelpers.GetSelectionFromMenu(availableFiles, "Select a schedule to load");
            if (fileIndex == -1) return;

            try
            {
                string filePath = Path.Combine(SCHEDULES_DIRECTORY, availableFiles[fileIndex]);
                var schedule = manager.LoadSchedule(filePath);
                manager.SetCurrentSchedule(schedule);
                Console.WriteLine("Schedule loaded successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading schedule: {ex.Message}");
            }
        }

        public override string MenuText()
        {
            return "Manage Schedule";
        }
    }
} 