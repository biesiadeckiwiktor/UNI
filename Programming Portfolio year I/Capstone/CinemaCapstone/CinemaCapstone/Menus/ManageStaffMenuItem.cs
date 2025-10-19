using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class ManageStaffMenuItem : MenuItem
    {
        private ManagerMenu _parentMenu;

        public ManageStaffMenuItem(ManagerMenu parentMenu)
        {
            _parentMenu = parentMenu;
        }

        public override void Select()
        {
            Console.WriteLine("Staff Management Menu");
            Console.WriteLine("1. Add Staff");
            Console.WriteLine("2. Remove Staff");
            Console.WriteLine("3. View All Staff");
            Console.WriteLine("4. Return to previous menu");
            
            int choice = ConsoleHelpers.GetIntegerInRange(1, 4, "Staff Management Menu");
            
            switch (choice)
            {
                case 1:
                    AddStaff();
                    break;
                case 2:
                    RemoveStaff();
                    break;
                case 3:
                    ViewAllStaff();
                    break;
                case 4:
                    // Return to previous menu
                    break;
            }
        }

        private void AddStaff()
        {
            Console.WriteLine("Enter staff name:");
            string name = Console.ReadLine();
            
            Console.WriteLine("Is this staff a manager? (Y/N)");
            string response = Console.ReadLine().ToUpper();
            bool isManager = response == "Y";
            
            _parentMenu.GetManager().AddStaff(name, isManager);
            
            Console.WriteLine("Staff added successfully.");
        }

        private void RemoveStaff()
        {
            Console.WriteLine("Enter staff ID to remove:");
            int staffId = int.Parse(Console.ReadLine());
            
            _parentMenu.GetManager().RemoveStaff(staffId);
            
            Console.WriteLine("Staff removed successfully.");
        }

        private void ViewAllStaff()
        {
            var allStaff = Staff.GetAllStaff();
            
            Console.WriteLine("All Staff:");
            foreach (var staff in allStaff)
            {
                Console.WriteLine($"ID: {staff.Id}, Name: {staff.Name}, Role: {staff.GetType().Name}");
            }
            
        }

        public override string MenuText()
        {
            return "Manage Staff";
        }
    }
} 