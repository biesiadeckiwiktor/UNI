using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class FinalizeTransactionMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public FinalizeTransactionMenuItem(ConsoleMenu parentMenu)
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
            
            if (staff.Sale == null)
            {
                Console.WriteLine("No active transaction. Please start a transaction first.");
                return;
            }
            
            // Increment visit count if customer has a loyalty scheme
            if (staff.Sale.Customer?.LoyaltyScheme != null)
            {
                staff.Sale.Customer.LoyaltyScheme.IncrementVisitCount();
            }
            
            // Finalize the transaction
            staff.FinalizeTransaction();
            
            Console.WriteLine("Transaction finalized.");
        }

        public override string MenuText()
        {
            return "Finalize transaction";
        }
    }
} 