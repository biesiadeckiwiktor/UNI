using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Capstone
{
    /// <summary>
    /// Represents a loyalty scheme in the cinema system.
    /// </summary>
    public class LoyaltyScheme
    {
        private static int _nextMembershipNumber = 1000;
        protected static List<LoyaltyScheme> _members = new List<LoyaltyScheme>();
        private int _membershipNumber;
        private DateTime _joinDate;
        private int _visitCount;
        private bool _isGold;
        private const string LOYALTY_SCHEME_DIRECTORY = "LoyaltySchemes";
        private const string LOYALTY_SCHEME_FILE_PREFIX = "loyalty_members_";

        static LoyaltyScheme()
        {
            LoadFromFile();
        }

        /// <summary>
        /// Loads the loyalty scheme data from file.
        /// </summary>
        private static void LoadFromFile()
        {
            try
            {
                if (!Directory.Exists(LOYALTY_SCHEME_DIRECTORY))
                {
                    Directory.CreateDirectory(LOYALTY_SCHEME_DIRECTORY);
                    return;
                }

                // Get the most recent file
                var files = Directory.GetFiles(LOYALTY_SCHEME_DIRECTORY, $"{LOYALTY_SCHEME_FILE_PREFIX}*.txt")
                                   .OrderByDescending(f => f)
                                   .ToList();

                if (files.Count == 0)
                {
                    Console.WriteLine("No loyalty scheme data files found.");
                    return;
                }

                string filePath = files[0];
                Console.WriteLine($"\nLoading loyalty scheme data from: {filePath}");

                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine($"Found {lines.Length} lines in the file");

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        try
                        {
                            int membershipNumber = int.Parse(parts[0]);
                            DateTime joinDate = DateTime.Parse(parts[1]);
                            bool isGold = bool.Parse(parts[2]);
                            int visitCount = int.Parse(parts[3]);

                            Console.WriteLine($"Loading member: {membershipNumber} ({(isGold ? "Gold" : "Standard")})");

                            var scheme = new LoyaltyScheme(isGold);
                            scheme._membershipNumber = membershipNumber;
                            scheme._joinDate = joinDate;
                            scheme._visitCount = visitCount;

                            // Update the next membership number if needed
                            if (membershipNumber >= _nextMembershipNumber)
                            {
                                _nextMembershipNumber = membershipNumber + 1;
                            }

                            Console.WriteLine($"Successfully loaded member {membershipNumber}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing line: {line}");
                            Console.WriteLine($"Error details: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line format: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading loyalty scheme data: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        /// <summary>
        /// Gets the membership number.
        /// </summary>
        public int MembershipNumber => _membershipNumber;

        /// <summary>
        /// Gets the join date.
        /// </summary>
        public DateTime JoinDate => _joinDate;

        /// <summary>
        /// Gets the number of visits.
        /// </summary>
        public int VisitCount => _visitCount;

        /// <summary>
        /// Gets whether the member is gold.
        /// </summary>
        public bool IsGold => _isGold;

        /// <summary>
        /// Initializes a new instance of the LoyaltyScheme class.
        /// </summary>
        public LoyaltyScheme(bool isGold = false)
        {
            _membershipNumber = _nextMembershipNumber++;
            _joinDate = DateTime.Now;
            _visitCount = 0;
            _isGold = isGold;
            _members.Add(this);
        }

        /// <summary>
        /// Increments the visit count for this member.
        /// </summary>
        public void IncrementVisitCount()
        {
            _visitCount++;
            SaveToFile();
        }

        /// <summary>
        /// Saves the loyalty scheme data to a file.
        /// </summary>
        private void SaveToFile()
        {
            try
            {
                if (!Directory.Exists(LOYALTY_SCHEME_DIRECTORY))
                {
                    Directory.CreateDirectory(LOYALTY_SCHEME_DIRECTORY);
                }

                string fileName = $"{LOYALTY_SCHEME_FILE_PREFIX}{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string filePath = Path.Combine(LOYALTY_SCHEME_DIRECTORY, fileName);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var member in _members)
                    {
                        writer.WriteLine($"{member.MembershipNumber}|{member.JoinDate:yyyy-MM-dd}|{member.IsGold}|{member.VisitCount}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving loyalty scheme data: {ex.Message}");
            }
        }

        /// <summary>
        /// Registers a new member in the loyalty scheme.
        /// </summary>
        /// <param name="firstName">The member's first name.</param>
        /// <param name="surname">The member's surname.</param>
        /// <param name="email">The member's email address.</param>
        /// <param name="isGold">Whether the member is gold.</param>
        /// <returns>A tuple containing success status, message, and membership number if successful.</returns>
        public static (bool success, string message, int? membershipNumber) RegisterMember(string firstName, string surname, string email, bool isGold = false)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(email))
            {
                return (false, "All fields are required.", null);
            }

            var member = new LoyaltyScheme(isGold);
            return (true, "Member registered successfully.", member.MembershipNumber);
        }

        /// <summary>
        /// Gets a member by their membership number.
        /// </summary>
        /// <param name="membershipNumber">The membership number to search for.</param>
        /// <returns>The member if found, null otherwise.</returns>
        public static LoyaltyScheme GetMember(int membershipNumber)
        {
            return _members.FirstOrDefault(m => m.MembershipNumber == membershipNumber);
        }

        /// <summary>
        /// Gets all members in the loyalty scheme.
        /// </summary>
        /// <returns>A list of all members.</returns>
        public static List<LoyaltyScheme> GetAllMembers()
        {
            return new List<LoyaltyScheme>(_members);
        }

        /// <summary>
        /// Returns a string representation of the loyalty scheme.
        /// </summary>
        public override string ToString()
        {
            return $"Membership #{_membershipNumber} ({(IsGold ? "Gold" : "Standard")}, Visits: {_visitCount})";
        }
    }
} 