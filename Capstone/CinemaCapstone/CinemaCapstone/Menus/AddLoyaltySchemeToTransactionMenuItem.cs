using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class AddLoyaltySchemeToTransactionMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public AddLoyaltySchemeToTransactionMenuItem(ConsoleMenu parentMenu)
        {
            _parentMenu = parentMenu;
        }

        public override void Select()
        {
            try
            {
                // Get membership number
                Console.Write("\nEnter membership number: ");
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out int membershipNumber))
                {
                    Console.WriteLine("Invalid number format");
                    return;
                }

                // Find the member and increment visit count
                var member = LoyaltyScheme.GetMember(membershipNumber);
                if (member != null)
                {
                    member.IncrementVisitCount();
                    Console.WriteLine($"Visit count incremented for member #{membershipNumber}");
                }
                else
                {
                    Console.WriteLine("Member not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public override string MenuText()
        {
            return "Add loyalty scheme to transaction";
        }
    }
} 