using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Capstone
{
    /// <summary>
    /// Handles loading configuration information from files.
    /// </summary>
    internal static class ConfigurationLoader
    {
        /// <summary>
        /// Loads all configuration information from a file.
        /// </summary>
        /// <param name="filePath">The path to the configuration file.</param>
        public static void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {filePath}");
            }

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                throw new InvalidDataException($"Configuration file is empty: {filePath}");
            }

            bool hasValidEntries = false;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    hasValidEntries = true;
                LoadFromLine(line);
                }
                else
                {
                    Console.WriteLine($"Warning: Invalid line format in {filePath}: {line}");
                }
            }

            if (!hasValidEntries)
            {
                throw new InvalidDataException($"No valid configuration entries found in file: {filePath}");
            }
        }

        /// <summary>
        /// Loads configuration information from a single line.
        /// </summary>
        /// <param name="line">The configuration line to process.</param>
        public static void LoadFromLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            // Process different types of configuration lines
            if (line.StartsWith("[Movie:"))
            {
                LoadMovieFromConfig(line);
            }
            else if (line.StartsWith("[Ticket:"))
            {
                LoadTicketFromConfig(line);
            }
            else if (line.StartsWith("[Concession:"))
            {
                LoadConcessionFromConfig(line);
            }
            else if (line.StartsWith("[Staff:"))
            {
                LoadStaffFromConfig(line);
            }
            else if (line.StartsWith("[Screen:"))
            {
                LoadScreenFromConfig(line);
            }
            // Add more configuration types as needed
        }

        /// <summary>
        /// Loads movie information from a configuration line.
        /// </summary>
        /// <param name="configLine">The configuration line in the format [Movie:Title%Length:Minutes%Genre:Type%Rating:Age].</param>
        private static void LoadMovieFromConfig(string configLine)
        {
            if (string.IsNullOrEmpty(configLine) || !configLine.StartsWith("[Movie:") || !configLine.EndsWith("]"))
            {
                return;
            }

            string content = configLine.Substring(7, configLine.Length - 8); // Remove [Movie: and ]
            string[] parts = content.Split('%');
            
            if (parts.Length >= 4)
            {
                string title = parts[0];
                if (int.TryParse(parts[1].Replace("Length:", ""), out int length) &&
                    parts[2].StartsWith("Genre:") &&
                    parts[3].StartsWith("Rating:"))
                {
                    string genre = parts[2].Replace("Genre:", "");
                    string rating = parts[3].Replace("Rating:", "");
                    new Movie(title, length, genre, rating);
                }
            }
        }

        /// <summary>
        /// Loads ticket information from a configuration line.
        /// </summary>
        /// <param name="configLine">The configuration line in the format [Ticket:Type%Price].</param>
        private static void LoadTicketFromConfig(string configLine)
        {
            if (string.IsNullOrEmpty(configLine) || !configLine.StartsWith("[Ticket:") || !configLine.EndsWith("]"))
            {
                return;
            }

            string content = configLine.Substring(8, configLine.Length - 9); // Remove [Ticket: and ]
            string[] parts = content.Split('%');
            
            if (parts.Length == 2 && int.TryParse(parts[1], out int price))
            {
                string type = parts[0];
                Ticket.AddTicketPrice(type, price);
            }
        }

        /// <summary>
        /// Loads concession information from a configuration line.
        /// </summary>
        /// <param name="configLine">The configuration line in the format [Concession:Name%Price:Price].</param>
        private static void LoadConcessionFromConfig(string configLine)
        {
            if (string.IsNullOrEmpty(configLine) || !configLine.StartsWith("[Concession:") || !configLine.EndsWith("]"))
            {
                return;
            }

            string content = configLine.Substring(12, configLine.Length - 13); // Remove [Concession: and ]
            string[] parts = content.Split('%');
            
            if (parts.Length == 2 && parts[1].StartsWith("Price:") && int.TryParse(parts[1].Replace("Price:", ""), out int price))
            {
                string name = parts[0];
                AddConcessionToCatalog(name, price);
            }
        }

        private static void AddConcessionToCatalog(string name, int price)
        {
                Concession.AddConcessionPrice(name, price);
        }

        /// <summary>
        /// Loads staff information from a configuration line.
        /// </summary>
        /// <param name="configLine">The configuration line in the format [Staff:ID%Level:Role%FirstName:Name%LastName:Surname].</param>
        private static void LoadStaffFromConfig(string configLine)
        {
            if (string.IsNullOrEmpty(configLine) || !configLine.StartsWith("[Staff:") || !configLine.EndsWith("]"))
            {
                return;
            }

            string content = configLine.Substring(7, configLine.Length - 8); // Remove [Staff: and ]
            string[] parts = content.Split('%');
            
            if (parts.Length >= 4)
            {
                string id = parts[0];
                string level = parts[1].Replace("Level:", "");
                string firstName = parts[2].Replace("FirstName:", "");
                string lastName = parts[3].Replace("LastName:", "");

                string fullName = $"{firstName} {lastName}";
                
                if (level.Equals("Manager", StringComparison.OrdinalIgnoreCase))
                {
                    new Manager(fullName);
                }
                else if (level.Equals("General", StringComparison.OrdinalIgnoreCase))
                {
                    new GeneralStaff(fullName);
                }
            }
        }

        /// <summary>
        /// Loads screen information from a configuration line.
        /// </summary>
        /// <param name="configLine">The configuration line in the format [Screen:Name%NumPremiumSeat:Number%NumStandardSeat:Number].</param>
        private static void LoadScreenFromConfig(string configLine)
        {
            if (string.IsNullOrEmpty(configLine) || !configLine.StartsWith("[Screen:") || !configLine.EndsWith("]"))
            {
                return;
            }

            string content = configLine.Substring(8, configLine.Length - 9); // Remove [Screen: and ]
            string[] parts = content.Split('%');
            
            if (parts.Length >= 3)
            {
                string name = parts[0];
                if (int.TryParse(parts[1].Replace("NumPremiumSeat:", ""), out int numPremiumSeats) &&
                    int.TryParse(parts[2].Replace("NumStandardSeat:", ""), out int numStandardSeats))
                {
                    new Screen(name, numPremiumSeats, numStandardSeats);
                }
            }
        }

        /// <summary>
        /// Loads all configuration information from multiple files.
        /// </summary>
        /// <param name="filePaths">The paths to the configuration files.</param>
        public static void LoadFromFiles(IEnumerable<string> filePaths)
        {
            foreach (string filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    LoadFromFile(filePath);
                }
            }
        }

        /// <summary>
        /// Gets all movies loaded from configuration files.
        /// </summary>
        /// <returns>A list of all loaded movies.</returns>
        public static List<Movie> GetAllMovies()
        {
            return Movie.GetAllMovies();
        }

        /// <summary>
        /// Gets all available ticket types.
        /// </summary>
        /// <returns>A list of all available ticket types.</returns>
        public static List<string> GetAllTicketTypes()
        {
            return Ticket.GetAllTicketTypes();
        }

        /// <summary>
        /// Gets all available concessions.
        /// </summary>
        /// <returns>A list of all available concession names.</returns>
        public static List<string> GetAllConcessions()
        {
            return Concession.GetAllConcessionNames();
        }

        public static void LoadConcessions()
        {
            // Add default concessions if none are loaded from configuration
            if (Concession.GetAllConcessionNames().Count == 0)
            {
                Concession.AddConcessionPrice("Popcorn", 300);  // £3.00
                Concession.AddConcessionPrice("Candy", 200);     // £2.00
                Concession.AddConcessionPrice("Soda", 250);      // £2.50
                Concession.AddConcessionPrice("Hot Dog", 400);   // £4.00
                Concession.AddConcessionPrice("Nachos", 350);    // £3.50
            }
        }

        /// <summary>
        /// Gets all available screens.
        /// </summary>
        /// <returns>A list of all available screens.</returns>
        public static List<Screen> GetAllScreens()
        {
            return Screen.GetAllScreens();
        }
    }
} 