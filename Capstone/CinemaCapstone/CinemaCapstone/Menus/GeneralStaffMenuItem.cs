using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class GeneralStaffMenuItem : MenuItem
    {
        private StaffSelectionMenu _parentMenu;

        public GeneralStaffMenuItem(StaffSelectionMenu parentMenu)
        {
            _parentMenu = parentMenu;
        }

        public override void Select()
        {
            // Create a new general staff member
            var staff = new GeneralStaff("General Staff");
            _parentMenu.SetCurrentStaff(staff);
            
            // Create and show the general staff menu
            var generalStaffMenu = new GeneralStaffMenu(staff);
            generalStaffMenu.Select();
        }

        public override string MenuText()
        {
            return "General Staff";
        }
    }
} 