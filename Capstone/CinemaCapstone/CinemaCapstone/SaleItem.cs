using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{/// <summary>
/// Parent class for all items availabe for sale. Ticket, concession and membership inherit from this class
/// </summary>
    public class SaleItem
    {
        private int _priceInPence;

        public int PriceInPence
        {
            get { return _priceInPence; }
        }

        public SaleItem(int priceInPence)
        {
            if (priceInPence <= 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative or 0");
            }
            _priceInPence = priceInPence;
        }
        public override string ToString()
        {
            return $"£{_priceInPence / 100.0:F2}";
        }
    }
}
