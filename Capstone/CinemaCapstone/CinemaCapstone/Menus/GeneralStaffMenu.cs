using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class GeneralStaffMenu : ConsoleMenu
    {
        private Staff _staff;

        public GeneralStaffMenu(Staff staff)
        {
            _staff = staff;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            
            // If there's no active sale, show the option to start a new sale
            if (_staff.Sale == null)
            {
                _menuItems.Add(new StartTransactionMenuItem(this));
            }
            else
            {
                // If there's an active sale, show options to add items to the sale
                _menuItems.Add(new AddTicketMenuItem(this));
                _menuItems.Add(new AddConcessionToTransactionMenuItem(this));
                _menuItems.Add(new AddLoyaltySchemeToTransactionMenuItem(this));
                _menuItems.Add(new UpgradeToGoldMembershipMenuItem(this));
                _menuItems.Add(new AddLoyaltySchemeMenuItem(this));
                _menuItems.Add(new FinalizeTransactionMenuItem(this));
            }
            
            // Add schedule viewing capability
            _menuItems.Add(new ViewScheduleMenuItem(this));
            
            // Add loyalty scheme management
            _menuItems.Add(new ManageLoyaltySchemeMenuItem(this));
            
            _menuItems.Add(new ReturnToMainMenuItem(this));
        }

        public override string MenuText()
        {
            if (_staff.Sale == null)
            {
                return "General Staff Menu - No active transaction";
            }
            else
            {
                return "General Staff Menu - Active transaction";
            }
        }

        public Staff GetStaff()
        {
            return _staff;
        }

        public override Sale GetCurrentSale()
        {
            return _staff.Sale;
        }
    }
} 