using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone.Menus
{
    internal class StaffSelectionMenu : ConsoleMenu
    {
        private Staff _currentStaff;

        public StaffSelectionMenu()
        {
            _currentStaff = null;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();

            // Get all staff members
            var allStaff = Staff.GetAllStaff();
            
            // Create menu items for each staff member
            foreach (var staff in allStaff)
            {
                _menuItems.Add(new StaffMenuItem($"{staff.Name} - {staff.GetType().Name}", () =>
                {
                    _currentStaff = staff;
                    
                    // Open appropriate menu based on staff type
                    if (staff is Manager manager)
                    {
                        var managerMenu = new ManagerMenu(manager);
                        managerMenu.Select();
                    }
                    else if (staff is GeneralStaff generalStaff)
                    {
                        var generalStaffMenu = new GeneralStaffMenu(generalStaff);
                        generalStaffMenu.Select();
                    }
                }));
            }

            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Welcome to Hull-ywood Cinema. Please select your name:";
        }

        public void SetCurrentStaff(Staff staff)
        {
            _currentStaff = staff;
        }

        public Staff GetCurrentStaff()
        {
            return _currentStaff;
        }
    }
} 