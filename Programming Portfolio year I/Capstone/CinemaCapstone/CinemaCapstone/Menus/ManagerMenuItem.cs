using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class ManagerMenuItem : MenuItem
    {
        private StaffSelectionMenu _parentMenu;

        public ManagerMenuItem(StaffSelectionMenu parentMenu)
        {
            _parentMenu = parentMenu;
        }

        public override void Select()
        {
            // Create a new manager
            var manager = new Manager("Manager");
            _parentMenu.SetCurrentStaff(manager);
            
            // Create and show the manager menu
            var managerMenu = new ManagerMenu(manager);
            managerMenu.Select();
        }

        public override string MenuText()
        {
            return "Manager";
        }
    }
} 