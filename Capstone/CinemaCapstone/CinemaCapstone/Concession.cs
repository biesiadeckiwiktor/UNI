using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone
{
    /// <summary>
    /// Represents a concession item in the cinema system.
    /// </summary>
    public class Concession : SaleItem
    {
        private string _name;
        internal static List<ConcessionPriceInfo> _concessionPrices = new List<ConcessionPriceInfo>();

        /// <summary>
        /// Represents concession price information.
        /// </summary>
        internal class ConcessionPriceInfo
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public ConcessionPriceInfo(string name, int price)
            {
                Name = name;
                Price = price;
            }
        }

        /// <summary>
        /// Gets the name of the concession.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the price in pence for a specific concession.
        /// </summary>
        /// <param name="name">The name of the concession.</param>
        /// <returns>The price in pence for the specified concession.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the concession is not found in the configuration.</exception>
        public static int GetPriceInPence(string name)
        {
            var concessionInfo = _concessionPrices.FirstOrDefault(c => c.Name == name);
            if (concessionInfo == null)
            {
                throw new KeyNotFoundException($"Concession '{name}' not found in configuration.");
            }
            return concessionInfo.Price;
        }

        /// <summary>
        /// Gets the discounted price in pence for a specific concession.
        /// </summary>
        /// <param name="name">The name of the concession.</param>
        /// <param name="discountPercentage">The discount percentage to apply.</param>
        /// <returns>The discounted price in pence.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the concession is not found in the configuration.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the discount percentage is invalid.</exception>
        public static int GetDiscountedPriceInPence(string name, decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 100.");
            }

            int originalPrice = GetPriceInPence(name);
            decimal discountMultiplier = 1 - (discountPercentage / 100);
            return (int)Math.Round(originalPrice * discountMultiplier);
        }

        /// <summary>
        /// Adds a new concession price to the configuration.
        /// </summary>
        /// <param name="name">The name of the concession.</param>
        /// <param name="price">The price in pence.</param>
        public static void AddConcessionPrice(string name, int price)
        {
            _concessionPrices.Add(new ConcessionPriceInfo(name, price));
        }

        /// <summary>
        /// Removes a concession type from the configuration.
        /// </summary>
        /// <param name="name">The name of the concession to remove.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the concession is not found in the configuration.</exception>
        public static void RemoveConcessionType(string name)
        {
            var concessionInfo = _concessionPrices.FirstOrDefault(c => c.Name == name);
            if (concessionInfo == null)
            {
                throw new KeyNotFoundException($"Concession '{name}' not found in configuration.");
            }
            _concessionPrices.Remove(concessionInfo);
        }

        /// <summary>
        /// Updates the price of an existing concession.
        /// </summary>
        /// <param name="name">The name of the concession.</param>
        /// <param name="newPrice">The new price in pence.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the concession is not found in the configuration.</exception>
        public static void UpdateConcessionPrice(string name, int newPrice)
        {
            var concessionInfo = _concessionPrices.FirstOrDefault(c => c.Name == name);
            if (concessionInfo == null)
            {
                throw new KeyNotFoundException($"Concession '{name}' not found in configuration.");
            }
            concessionInfo.Price = newPrice;
        }

        /// <summary>
        /// Gets all available concession names.
        /// </summary>
        /// <returns>A list of all available concession names.</returns>
        public static List<string> GetAllConcessionNames()
        {
            return _concessionPrices.Select(c => c.Name).ToList();
        }

        /// <summary>
        /// Initializes a new instance of the Concession class.
        /// </summary>
        /// <param name="name">The name of the concession.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the concession is not found in the configuration.</exception>
        public Concession(string name) 
            : base(GetPriceInPence(name))
        {
            _name = name;
        }

        /// <summary>
        /// Returns a string representation of the concession.
        /// </summary>
        public override string ToString()
        {
            return _name;
        }
    }
} 