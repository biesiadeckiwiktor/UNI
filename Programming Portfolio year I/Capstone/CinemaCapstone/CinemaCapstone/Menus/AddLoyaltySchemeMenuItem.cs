using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class AddLoyaltySchemeMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public AddLoyaltySchemeMenuItem(ConsoleMenu parentMenu)
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

            Console.WriteLine("\n=== Register New Loyalty Scheme Member ===");
            Console.WriteLine("Please enter the customer's details to create a new loyalty scheme membership.");
            Console.WriteLine("A new membership number will be assigned automatically.\n");

            string firstName = ConsoleHelpers.GetString("First name");
            string surname = ConsoleHelpers.GetString("Surname");
            string email = ConsoleHelpers.GetString("Email");

            // Create a new customer
            staff.Sale.Customer = new Customer(firstName, surname, email);

            var (success, message, membershipNumber) = LoyaltyScheme.RegisterMember(firstName, surname, email);

            if (success && membershipNumber.HasValue)
            {
                staff.Sale.Customer.LoyaltyScheme = LoyaltyScheme.GetMember(membershipNumber.Value);
                Console.WriteLine($"\nSuccessfully registered new loyalty scheme member!");
                Console.WriteLine($"Membership number: {membershipNumber.Value}");
                Console.WriteLine("You can now use this membership number for future transactions.");
            }
            else
            {
                Console.WriteLine($"\nFailed to register customer: {message}");
            }
        }

        public override string MenuText()
        {
            return "Register new loyalty scheme member";
        }
    }
} 