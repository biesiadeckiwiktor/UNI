using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    /// <summary>
    /// Represents a sale in the cinema system.
    /// </summary>
    public class Sale
    {
        private List<SaleItem> _items;
        private Customer _customer;
        private DateTime _dateTime;

        /// <summary>
        /// Gets the customer associated with this sale.
        /// </summary>
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        /// <summary>
        /// Gets the date and time of the sale.
        /// </summary>
        public DateTime DateTime
        {
            get { return _dateTime; }
        }

        /// <summary>
        /// Gets the total price of the sale in pence.
        /// </summary>
        public int TotalPrice
        {
            get { return _items.Sum(item => item.PriceInPence); }
        }

        /// <summary>
        /// Gets the items in the sale.
        /// </summary>
        public IReadOnlyList<SaleItem> Items
        {
            get { return _items.AsReadOnly(); }
        }

        /// <summary>
        /// Initializes a new instance of the Sale class.
        /// </summary>
        public Sale()
        {
            _items = new List<SaleItem>();
            _dateTime = DateTime.Now;
        }

        /// <summary>
        /// Adds an item to the sale.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(SaleItem item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Returns a string representation of the sale.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int saleTotalInPence = 0;
            foreach (SaleItem saleItem in _items)
            {
                sb.Append(saleItem.ToString());
                saleTotalInPence += saleItem.PriceInPence;
            }
            sb.AppendLine($"Total : £{saleTotalInPence / 100.0:F2}");
            return sb.ToString();
        }
    }
}
