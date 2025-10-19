using System;
using System.Collections.Generic;

namespace Capstone
{
    public class Screening
    {
        public Movie Movie { get; private set; }
        public Screen Screen { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        private Dictionary<string, bool> _premiumSeats;
        private Dictionary<string, bool> _standardSeats;

        public Screening(Movie movie, Screen screen, DateTime startTime)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie cannot be null");
            if (screen == null)
                throw new ArgumentNullException(nameof(screen), "Screen cannot be null");

            Movie = movie;
            Screen = screen;
            StartTime = startTime;
            EndTime = startTime.AddMinutes(movie.LengthInMinutes);

            // Initialize seat dictionaries
            _premiumSeats = new Dictionary<string, bool>();
            _standardSeats = new Dictionary<string, bool>();

            // Create premium seats (P1, P2, etc.)
            for (int i = 1; i <= screen.NumPremiumSeats; i++)
            {
                string seatNumber = $"P{i}";
                _premiumSeats.Add(seatNumber, false);
            }

            // Create standard seats (S1, S2, etc.)
            for (int i = 1; i <= screen.NumStandardSeats; i++)
            {
                string seatNumber = $"S{i}";
                _standardSeats.Add(seatNumber, false);
            }
        }

        public bool IsSeatAvailable(string seatNumber, bool isPremium)
        {
            var seats = isPremium ? _premiumSeats : _standardSeats;
            return seats.ContainsKey(seatNumber) && !seats[seatNumber];
        }

        public void BookSeat(string seatNumber, bool isPremium)
        {
            var seats = isPremium ? _premiumSeats : _standardSeats;
            if (!seats.ContainsKey(seatNumber))
                throw new ArgumentException("Invalid seat number", nameof(seatNumber));
            if (seats[seatNumber])
                throw new InvalidOperationException("Seat is already booked");

            seats[seatNumber] = true;
        }

        public void ReleaseSeat(string seatNumber, bool isPremium)
        {
            var seats = isPremium ? _premiumSeats : _standardSeats;
            if (!seats.ContainsKey(seatNumber))
                throw new ArgumentException("Invalid seat number", nameof(seatNumber));
            if (!seats[seatNumber])
                throw new InvalidOperationException("Seat is not booked");

            seats[seatNumber] = false;
        }

        public List<string> GetAvailablePremiumSeats()
        {
            return _premiumSeats.Where(s => !s.Value).Select(s => s.Key).ToList();
        }

        public List<string> GetAvailableStandardSeats()
        {
            return _standardSeats.Where(s => !s.Value).Select(s => s.Key).ToList();
        }

        public bool OverlapsWith(Screening other)
        {
            return Screen == other.Screen &&
                   ((StartTime <= other.StartTime && EndTime > other.StartTime) ||
                    (StartTime < other.EndTime && EndTime >= other.EndTime) ||
                    (StartTime >= other.StartTime && EndTime <= other.EndTime));
        }

        public int GetRequiredTurnaroundTime()
        {
            int totalSeats = Screen.NumPremiumSeats + Screen.NumStandardSeats;
            if (totalSeats <= 50) return 15;
            if (totalSeats <= 100) return 30;
            return 45;
        }

        public override string ToString()
        {
            return $"{Movie.Title} in {Screen.Name} at {StartTime:HH:mm} (Premium seats: {GetAvailablePremiumSeats().Count}/{Screen.NumPremiumSeats}, Standard seats: {GetAvailableStandardSeats().Count}/{Screen.NumStandardSeats})";
        }
    }
} 