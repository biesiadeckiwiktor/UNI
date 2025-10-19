using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class ManagerMenu : ConsoleMenu
    {
        private Manager _manager;

        public ManagerMenu(Manager manager)
        {
            _manager = manager;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            
            // If there's no active sale, show the option to start a new sale
            if (_manager.Sale == null)
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
            
            // Manager-specific options
            _menuItems.Add(new ManageStaffMenuItem(this));
            _menuItems.Add(new ManageScheduleMenuItem(this));
            _menuItems.Add(new ManageConcessionCatalogMenuItem(this));
            
            // Add loyalty scheme management
            _menuItems.Add(new ManageLoyaltySchemeMenuItem(this));
            
            _menuItems.Add(new ReturnToMainMenuItem(this));
        }

        public override string MenuText()
        {
            if (_manager.Sale == null)
            {
                return "Manager Menu - No active transaction";
            }
            else
            {
                return "Manager Menu - Active transaction";
            }
        }

        public Manager GetManager()
        {
            return _manager;
        }

        public override Sale GetCurrentSale()
        {
            return _manager.Sale;
        }
    }
}  