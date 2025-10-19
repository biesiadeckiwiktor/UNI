using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone
{
    public abstract class Staff
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        protected static List<Staff> _allStaff = new List<Staff>();
        protected static int _nextStaffId = 1;
        private Sale _sale;
        private Schedule _currentSchedule;

        protected Staff(string name)
        {
            Id = _nextStaffId++;
            Name = name;
            _allStaff.Add(this);
        }

        public static Staff IdentifyStaff(int staffId)
        {
            return _allStaff.FirstOrDefault(s => s.Id == staffId);
        }

        public static List<Staff> GetAllStaff()
        {
            return new List<Staff>(_allStaff);
        }

        // Property to access the current sale
        public Sale Sale
        {
            get { return _sale; }
            protected set { _sale = value; }
        }

        // Schedule-related methods
        public Schedule GetCurrentSchedule()
        {
            return _currentSchedule;
        }

        public void SetCurrentSchedule(Schedule schedule)
        {
            _currentSchedule = schedule;
        }

        // General staff functionality
        public virtual void StartTransaction()
        {
            _sale = new Sale();
        }

        public virtual void AddTicketToTransaction(Ticket ticket)
        {
            if (_sale == null)
            {
                throw new InvalidOperationException("No active transaction. Please start a transaction first.");
            }
            _sale.AddItem(ticket);
        }

        public virtual void AddConcessionToTransaction(Concession concession)
        {
            if (Sale == null)
            {
                throw new InvalidOperationException("No active sale. Start a sale first.");
            }

            // Check if customer has a gold membership
            if (Sale.Customer?.LoyaltyScheme is GoldMembership goldMembership && goldMembership.IsValid())
            {
                // Apply 25% discount
                decimal discountPercentage = goldMembership.GetConcessionDiscount() * 100;
                int discountedPrice = Concession.GetDiscountedPriceInPence(concession.Name, discountPercentage);
                
                // Store the original price
                int originalPrice = Concession.GetPriceInPence(concession.Name);
                
                try
                {
                    // Temporarily update the price in the catalog
                    Concession.UpdateConcessionPrice(concession.Name, discountedPrice);
                    
                    // Create a new concession with the discounted price
                    Concession discountedConcession = new Concession(concession.Name);
                    Sale.AddItem(discountedConcession);
                    
                    Console.WriteLine($"Applied {discountPercentage}% Gold Membership discount to {concession.Name}");
                }
                finally
                {
                    // Restore the original price
                    Concession.UpdateConcessionPrice(concession.Name, originalPrice);
                }
            }
            else
            {
                // No discount, add the original concession
                Sale.AddItem(concession);
            }
        }

        public virtual void AddGoldMembershipToTransaction(SaleItem goldMembership)
        {
            if (_sale == null)
            {
                throw new InvalidOperationException("No active transaction. Please start a transaction first.");
            }
            _sale.AddItem(goldMembership);
        }

        public virtual void AddLoyaltySchemeToTransaction(SaleItem loyaltyScheme)
        {
            if (_sale == null)
            {
                throw new InvalidOperationException("No active transaction. Please start a transaction first.");
            }
            _sale.AddItem(loyaltyScheme);
        }

        public virtual void FinalizeTransaction()
        {
            if (_sale == null)
            {
                throw new InvalidOperationException("No active transaction. Please start a transaction first.");
            }
            // Implementation for finalizing transaction and updating seat numbers
            // This would need to be implemented based on your specific requirements
            _sale = null; // Clear the sale after finalizing
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name})";
        }
    }
} 