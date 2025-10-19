using System;
using System.Collections.Generic;

namespace Capstone
{
    public class Screen
    {
        public string Name { get; private set; }
        public int NumPremiumSeats { get; private set; }
        public int NumStandardSeats { get; private set; }
        private static List<Screen> _allScreens = new List<Screen>();

        public Screen(string name, int numPremiumSeats, int numStandardSeats)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Screen name cannot be empty", nameof(name));
            if (numPremiumSeats < 0)
                throw new ArgumentException("Number of premium seats cannot be negative", nameof(numPremiumSeats));
            if (numStandardSeats < 0)
                throw new ArgumentException("Number of standard seats cannot be negative", nameof(numStandardSeats));

            Name = name;
            NumPremiumSeats = numPremiumSeats;
            NumStandardSeats = numStandardSeats;
            _allScreens.Add(this);
        }

        public static List<Screen> GetAllScreens()
        {
            return new List<Screen>(_allScreens);
        }

        public static Screen GetScreenByName(string name)
        {
            return _allScreens.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int GetTotalSeats()
        {
            return NumPremiumSeats + NumStandardSeats;
        }

        public override string ToString()
        {
            return $"{Name} (Premium: {NumPremiumSeats}, Standard: {NumStandardSeats})";
        }
    }
} 