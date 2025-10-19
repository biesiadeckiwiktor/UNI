using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class ReturnToMainMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public ReturnToMainMenuItem(ConsoleMenu parentMenu)
        {
            _parentMenu = parentMenu;
        }

        public override void Select()
        {
            if (_parentMenu is GeneralStaffMenu generalStaffMenu)
            {
                generalStaffMenu.IsActive = false;
            }
            else if (_parentMenu is ManagerMenu managerMenu)
            {
                managerMenu.IsActive = false;
            }
        }

        public override string MenuText()
        {
            return "Return to main menu";
        }
    }
} 