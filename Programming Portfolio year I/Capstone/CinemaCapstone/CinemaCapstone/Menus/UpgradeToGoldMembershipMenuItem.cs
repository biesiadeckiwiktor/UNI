using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class UpgradeToGoldMembershipMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public UpgradeToGoldMembershipMenuItem(ConsoleMenu parentMenu)
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
            
            // Ask if client wants to upgrade to gold membership
            Console.WriteLine("\nWould you like to upgrade to our Gold Membership?");
            Console.WriteLine("Benefits:");
            Console.WriteLine("- 25% discount on all concessions");
            Console.WriteLine("- All benefits of regular loyalty scheme");
            Console.WriteLine("- Annual membership for £30");
            Console.WriteLine("\n1. Yes, I want to upgrade");
            Console.WriteLine("2. No, thank you");
            
            int choice = ConsoleHelpers.GetIntegerInRange(1, 2, "Would you like to upgrade to Gold Membership?");
            
            if (choice == 1)
            {
                // Get membership number
                Console.Write("\nPlease enter your loyalty scheme membership number: ");
                if (int.TryParse(Console.ReadLine(), out int membershipNumber))
                {
                    // Try to upgrade to gold membership
                    var (success, message, goldMembership) = GoldMembership.UpgradeToGold(membershipNumber);
                    
                    if (success && goldMembership != null)
                    {
                        // Create a SaleItem for the gold membership with just the price
                        var goldMembershipItem = new SaleItem(3000); // £30.00 in pence
                        
                        // Add gold membership to transaction
                        staff.AddLoyaltySchemeToTransaction(goldMembershipItem);
                        
                        Console.WriteLine("\nCongratulations! You are now a Gold Member!");
                        Console.WriteLine($"Membership details: {goldMembership}");
                        Console.WriteLine("You will receive 25% off all concessions with this membership.");
                    }
                    else
                    {
                        Console.WriteLine($"\nError upgrading to Gold Membership: {message}");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid membership number format.");
                }
            }
            else
            {
                Console.WriteLine("\nNo problem! You can always upgrade to Gold Membership later.");
            }
        }

        public override string MenuText()
        {
            return "Upgrade to Gold Membership";
        }
    }
} 