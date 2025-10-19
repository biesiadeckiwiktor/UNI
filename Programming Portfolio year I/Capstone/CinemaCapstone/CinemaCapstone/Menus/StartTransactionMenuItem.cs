using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class StartTransactionMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public StartTransactionMenuItem(ConsoleMenu parentMenu)
        {
            _parentMenu = parentMenu;
        }

        public override void Select()
        {
            Staff staff = null;
            
            if (_parentMenu is GeneralStaffMenu generalStaffMenu)
            {
                staff = generalStaffMenu.GetStaff();
            }
            else if (_parentMenu is ManagerMenu managerMenu)
            {
                staff = managerMenu.GetManager();
            }
            
            // Start a new transaction
            staff.StartTransaction();
            Console.WriteLine("New transaction started.");
        }

        public override string MenuText()
        {
            return "Start a new transaction";
        }
    }
} 