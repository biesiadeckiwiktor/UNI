using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class AddConcessionToTransactionMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public AddConcessionToTransactionMenuItem(ConsoleMenu parentMenu)
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
            
            // Get available concessions
            List<string> availableConcessions = ConfigurationLoader.GetAllConcessions();
            
            if (availableConcessions.Count == 0)
            {
                Console.WriteLine("No concessions available.");
                return;
            }
            
            // Display available concessions
            Console.WriteLine("Available Concessions:");
            for (int i = 0; i < availableConcessions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableConcessions[i]}");
            }
            
            // Get user selection
            int selection = ConsoleHelpers.GetIntegerInRange(1, availableConcessions.Count, "Select a concession");
            
            if (selection > 0 && selection <= availableConcessions.Count)
            {
                string selectedConcessionName = availableConcessions[selection - 1];
                
                // Ask for number of concessions
                Console.WriteLine($"\nHow many {selectedConcessionName} would you like?");
                int numberOfConcessions;
                while (true)
                {
                    Console.Write("Enter number of concessions: ");
                    if (int.TryParse(Console.ReadLine(), out numberOfConcessions) && numberOfConcessions > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Please enter a valid positive number.");
                }
                
                try
                {
                    // Add the specified number of concessions to the transaction
                    for (int i = 0; i < numberOfConcessions; i++)
                    {
                        Concession concession = CreateConcessionFromCatalog(selectedConcessionName);
                        staff.AddConcessionToTransaction(concession);
                    }
                    
                    Console.WriteLine($"Added {numberOfConcessions} {selectedConcessionName} to transaction.");
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding concession: {ex.Message}");
                }
            }
        }

        public override string MenuText()
        {
            return "Add concession to current transaction";
        }

        private Concession CreateConcessionFromCatalog(string name)
        {
            return new Concession(name);
        }
    }
} 