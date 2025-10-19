using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Capstone
{
    public class Manager : Staff
    {
        private Schedule _currentSchedule;

        public Manager(string name) : base(name)
        {
        }

        public Schedule GetCurrentSchedule()
        {
            return _currentSchedule;
        }

        public void SetCurrentSchedule(Schedule schedule)
        {
            _currentSchedule = schedule;
        }

        // Manager inherits all the base functionality from Staff
        // and adds the following manager-specific methods

        public void AddStaff(string name, bool isManager)
        {
            if (isManager)
            {
                new Manager(name);
            }
            else
            {
                new GeneralStaff(name);
            }
        }

        public void RemoveStaff(int staffId)
        {
            var staffToRemove = _allStaff.FirstOrDefault(s => s.Id == staffId);
            if (staffToRemove != null)
            {
                _allStaff.Remove(staffToRemove);
            }
        }

        public void SetDailySchedule(DateTime date, List<Staff> staffSchedule)
        {
            // Implementation for setting daily schedules
            // This would need to be implemented based on your scheduling rules
        }

        public void AddScreeningToSchedule(Schedule schedule, Screening screening)
        {
            schedule.AddScreening(screening);
        }

        public void RemoveScreeningFromSchedule(Schedule schedule, Screening screening)
        {
            schedule.RemoveScreening(screening);
        }

        public void SaveSchedule(Schedule schedule, string directory)
        {
            schedule.SaveToFile(directory);
        }

        public Schedule LoadSchedule(string filePath)
        {
            return Schedule.LoadFromFile(filePath);
        }

        public List<string> GetAvailableScheduleFiles(string directory)
        {
            if (!Directory.Exists(directory))
                return new List<string>();

            return Directory.GetFiles(directory, "schedule_*.fs")
                          .Select(Path.GetFileName)
                          .ToList();
        }

        public void RemoveConcession(string name)
        {
            // Implementation for removing concessions
            // This would need to be implemented based on your concession rules
        }

        public void EditConcession(string name, decimal newPrice)
        {
            // Implementation for editing concession prices
            // This would need to be implemented based on your concession rules
        }
    }
} 