using System;
using System.Collections.Generic;

namespace Capstone.Menus
{
    internal class ManageConcessionCatalogMenuItem : MenuItem
    {
        private ManagerMenu _parentMenu;

        public ManageConcessionCatalogMenuItem(ManagerMenu parentMenu)
        {
            _parentMenu = parentMenu;
        }

        public override void Select()
        {
            Console.WriteLine("Concession Catalog Management");
            Console.WriteLine("1. Add New Concession");
            Console.WriteLine("2. Remove Concession");
            Console.WriteLine("3. Edit Concession Price");
            Console.WriteLine("4. View All Concessions");
            Console.WriteLine("5. Return to previous menu");
            
            int choice = ConsoleHelpers.GetIntegerInRange(1, 5, "Concession Catalog Management");
            
            switch (choice)
            {
                case 1:
                    AddConcession();
                    break;
                case 2:
                    RemoveConcession();
                    break;
                case 3:
                    EditConcessionPrice();
                    break;
                case 4:
                    ViewAllConcessions();
                    break;
                case 5:
                    // Return to previous menu
                    break;
            }
        }

        private void AddConcession()
        {
            Console.WriteLine("Enter new concession name:");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter concession price in pence:");
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                try
                {
                    Concession.AddConcessionPrice(name, price);
                    Console.WriteLine("New concession added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding concession: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid price format. Please enter a whole number.");
            }
        }

        private void RemoveConcession()
        {
            Console.WriteLine("Enter concession name to remove:");
            string name = Console.ReadLine();
            
            try
            {
                Concession.RemoveConcessionType(name);
                Console.WriteLine("Concession removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing concession: {ex.Message}");
            }
        }

        private void EditConcessionPrice()
        {
            Console.WriteLine("Enter concession name to edit:");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter new price in pence:");
            if (int.TryParse(Console.ReadLine(), out int newPrice))
            {
                try
                {
                    Concession.UpdateConcessionPrice(name, newPrice);
                    Console.WriteLine("Concession price updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating concession price: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid price format. Please enter a whole number.");
            }
        }

        private void ViewAllConcessions()
        {
            Console.WriteLine("\nAll Available Concessions:");
            Console.WriteLine(new string('-', 40));
            
            var concessions = Concession.GetAllConcessionNames();
            if (concessions.Count == 0)
            {
                Console.WriteLine("No concessions available.");
            }
            else
            {
                foreach (string concessionName in concessions)
                {
                    try
                    {
                        int price = Concession.GetPriceInPence(concessionName);
                        Console.WriteLine($"{concessionName} - £{price / 100.0:F2}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine($"{concessionName} - Price not set");
                    }
                }
            }
            
            Console.WriteLine(new string('-', 40));
            ConsoleHelpers.PauseForUser();
        }

        public override string MenuText()
        {
            return "Manage Concession Catalog";
        }
    }
} 