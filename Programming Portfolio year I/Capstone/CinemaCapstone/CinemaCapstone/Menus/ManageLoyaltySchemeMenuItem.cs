using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Capstone.Menus
{
    internal class ManageLoyaltySchemeMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;
        private const string LOYALTY_SCHEME_DIRECTORY = "LoyaltySchemes";

        public ManageLoyaltySchemeMenuItem(ConsoleMenu parentMenu)
        {
            _parentMenu = parentMenu;
            if (!Directory.Exists(LOYALTY_SCHEME_DIRECTORY))
            {
                Directory.CreateDirectory(LOYALTY_SCHEME_DIRECTORY);
            }
        }

        public override void Select()
        {
            while (true)
            {
                Console.WriteLine("\nLoyalty Scheme Management");
                Console.WriteLine("1. Export Current Members");
                Console.WriteLine("2. View Exported Members");
                Console.WriteLine("3. Return to Previous Menu");

                int choice = ConsoleHelpers.GetIntegerInRange(1, 3, "Select an option");

                switch (choice)
                {
                    case 1:
                        ExportMembers();
                        break;
                    case 2:
                        ViewExportedMembers();
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void ExportMembers()
        {
            var members = LoyaltyScheme.GetAllMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("No members in the loyalty scheme to export.");
                return;
            }

            string fileName = $"loyalty_members_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(LOYALTY_SCHEME_DIRECTORY, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var member in members)
                    {
                        writer.WriteLine($"{member.MembershipNumber}|{member.JoinDate:yyyy-MM-dd}|{member.GetType().Name}|{member.VisitCount}");
                    }
                }
                Console.WriteLine($"Successfully exported {members.Count} members to {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting members: {ex.Message}");
            }
        }

        private void ViewExportedMembers()
        {
            var files = GetAvailableLoyaltySchemeFiles();
            if (files.Count == 0)
            {
                Console.WriteLine("No exported loyalty scheme files available.");
                return;
            }

            int fileIndex = ConsoleHelpers.GetSelectionFromMenu(files, "Select a file to view");
            if (fileIndex == -1) return;

            try
            {
                string filePath = Path.Combine(LOYALTY_SCHEME_DIRECTORY, files[fileIndex]);
                string[] lines = File.ReadAllLines(filePath);
                
                Console.WriteLine($"\nMembers from {files[fileIndex]}:");
                Console.WriteLine("Membership # | Join Date | Scheme Type | Visits");
                Console.WriteLine("------------------------------------------------");

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        Console.WriteLine($"{parts[0],-12} | {parts[1],-10} | {parts[2],-12} | {parts[3]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        private List<string> GetAvailableLoyaltySchemeFiles()
        {
            var files = new List<string>();
            if (Directory.Exists(LOYALTY_SCHEME_DIRECTORY))
            {
                files.AddRange(Directory.GetFiles(LOYALTY_SCHEME_DIRECTORY, "loyalty_members_*.txt"));
                for (int i = 0; i < files.Count; i++)
                {
                    files[i] = Path.GetFileName(files[i]);
                }
            }
            return files;
        }

        public override string MenuText()
        {
            return "Manage Loyalty Scheme";
        }
    }
} 