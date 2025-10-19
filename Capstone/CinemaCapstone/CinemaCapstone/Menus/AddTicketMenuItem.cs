using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone.Menus
{
    internal class AddTicketMenuItem : MenuItem
    {
        private ConsoleMenu _parentMenu;

        public AddTicketMenuItem(ConsoleMenu parentMenu)
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
            
            // Get ticket details from user
            Console.WriteLine("Enter ticket details:");
            
            // Show available movies and get selection
            var movies = Movie.GetAllMovies();
            var movieTitles = movies.Select(m => m.ToString()).ToList();
            
            int selection = ConsoleHelpers.GetSelectionFromMenu(movieTitles, "\nAvailable Movies:");
            
            if (selection == -1)
            {
                Console.WriteLine("No movies available.");
                return;
            }
            
            Movie selectedMovie = movies[selection];
            
            // Ask for number of tickets
            Console.WriteLine($"\nHow many tickets would you like for {selectedMovie}?");
            int numberOfTickets;
            while (true)
            {
                Console.Write("Enter number of tickets: ");
                if (int.TryParse(Console.ReadLine(), out numberOfTickets) && numberOfTickets > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid positive number.");
            }
            
            // Check age rating for the group
            bool ageVerified = true;
            if (numberOfTickets > 1)
            {
                Console.WriteLine($"\nThis movie has an age rating of {selectedMovie.AgeRating}.");
                Console.WriteLine("Does everyone in your group meet this age requirement? (Y/N)");
                string response = Console.ReadLine().ToUpper();
                ageVerified = response == "Y";
            }
            
            if (ageVerified)
            {
                // Ask for ticket type
                Console.WriteLine("\nSelect ticket type:");
                Console.WriteLine("1. Standard Ticket");
                Console.WriteLine("2. Premium Ticket");
                int ticketTypeChoice = ConsoleHelpers.GetIntegerInRange(1, 2, "Enter your choice (1-2):");
                
                // Add the specified number of tickets to the transaction
                for (int i = 0; i < numberOfTickets; i++)
                {
                    Ticket ticket;
                    if (ticketTypeChoice == 1)
                    {
                        ticket = new StandardTicket(selectedMovie);
                    }
                    else
                    {
                        ticket = new PremiumTicket(selectedMovie);
                    }
                    staff.AddTicketToTransaction(ticket);
                }
                
                string ticketType = ticketTypeChoice == 1 ? "Standard" : "Premium";
                Console.WriteLine($"{numberOfTickets} {ticketType} ticket(s) added to transaction.");
            }
            else
            {
                Console.WriteLine("Ticket purchase cancelled due to age rating requirements.");
            }
        }

        public override string MenuText()
        {
            return "Add ticket to transaction";
        }
    }
} 