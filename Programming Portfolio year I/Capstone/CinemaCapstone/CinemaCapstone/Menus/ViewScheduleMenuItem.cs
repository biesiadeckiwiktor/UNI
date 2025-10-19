using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Menus
{
    internal class ViewScheduleMenuItem : MenuItem
    {
        private GeneralStaffMenu _parentMenu;
        private const string SCHEDULES_DIRECTORY = "Schedules";

        public ViewScheduleMenuItem(GeneralStaffMenu parentMenu)
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
                Console.WriteLine("\nSchedule View Menu");
                Console.WriteLine("1. View Schedule");
                Console.WriteLine("2. Load Schedule");
                Console.WriteLine("3. Return to Previous Menu");

                int choice = ConsoleHelpers.GetIntegerInRange(1, 3, "Select an option");

                switch (choice)
                {
                    case 1:
                        ViewSchedule();
                        break;
                    case 2:
                        LoadSchedule();
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void ViewSchedule()
        {
            var staff = _parentMenu.GetStaff();
            var schedule = staff.GetCurrentSchedule();
            if (schedule == null)
            {
                Console.WriteLine("No active schedule. Please load a schedule first.");
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

        private void LoadSchedule()
        {
            var staff = _parentMenu.GetStaff();
            var availableFiles = GetAvailableScheduleFiles();
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
                var schedule = Schedule.LoadFromFile(filePath);
                staff.SetCurrentSchedule(schedule);
                Console.WriteLine($"Schedule loaded successfully for {schedule.Date:dd/MM/yyyy}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading schedule: {ex.Message}");
            }
        }

        private List<string> GetAvailableScheduleFiles()
        {
            var files = new List<string>();
            if (Directory.Exists(SCHEDULES_DIRECTORY))
            {
                files.AddRange(Directory.GetFiles(SCHEDULES_DIRECTORY, "schedule_*.fs"));
                for (int i = 0; i < files.Count; i++)
                {
                    files[i] = Path.GetFileName(files[i]);
                }
            }
            return files;
        }

        public override string MenuText()
        {
            return "View Schedule";
        }
    }
} 