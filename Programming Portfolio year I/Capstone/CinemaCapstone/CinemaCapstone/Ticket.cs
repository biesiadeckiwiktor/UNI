using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone
{
    /// <summary>
    /// Represents a ticket in the cinema system.
    /// </summary>
    public abstract class Ticket : SaleItem
    {
        private string _ticketType;
        private Movie _movie;
        private static List<TicketPriceInfo> _ticketPrices = new List<TicketPriceInfo>();

        /// <summary>
        /// Represents ticket price information.
        /// </summary>
        private class TicketPriceInfo
        {
            public string Type { get; set; }
            public int Price { get; set; }

            public TicketPriceInfo(string type, int price)
            {
                Type = type;
                Price = price;
            }
        }

        /// <summary>
        /// Gets the type of the ticket.
        /// </summary>
        public string TicketType
        {
            get { return _ticketType; }
        }

        /// <summary>
        /// Gets the movie associated with the ticket.
        /// </summary>
        public Movie Movie
        {
            get { return _movie; }
        }

        /// <summary>
        /// Gets the price in pence for a specific ticket type.
        /// </summary>
        /// <param name="type">The type of the ticket.</param>
        /// <returns>The price in pence for the specified ticket type.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the ticket type is not found in the configuration.</exception>
        public static int GetPriceInPence(string type)
        {
            var ticketInfo = _ticketPrices.FirstOrDefault(t => t.Type == type);
            if (ticketInfo == null)
            {
                throw new KeyNotFoundException($"Ticket type '{type}' not found in configuration.");
            }
            return ticketInfo.Price;
        }

        /// <summary>
        /// Adds a new ticket price to the configuration.
        /// </summary>
        /// <param name="type">The type of the ticket.</param>
        /// <param name="price">The price in pence.</param>
        public static void AddTicketPrice(string type, int price)
        {
            _ticketPrices.Add(new TicketPriceInfo(type, price));
        }

        /// <summary>
        /// Gets all available ticket types.
        /// </summary>
        /// <returns>A list of all available ticket types.</returns>
        public static List<string> GetAllTicketTypes()
        {
            return _ticketPrices.Select(t => t.Type).ToList();
        }

        /// <summary>
        /// Creates a new ticket instance from a type and movie.
        /// </summary>
        /// <param name="type">The type of the ticket.</param>
        /// <param name="movie">The movie associated with the ticket.</param>
        /// <returns>A new Ticket instance.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the ticket type is not found in the configuration.</exception>
        public static Ticket CreateFromType(string type, Movie movie)
        {
            switch (type.ToLower())
            {
                case "standard":
                    return new StandardTicket(movie);
                case "premium":
                    return new PremiumTicket(movie);
                default:
                    throw new KeyNotFoundException($"Ticket type '{type}' not found in configuration.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the Ticket class.
        /// </summary>
        /// <param name="ticketType">The type of the ticket (Standard or Premium).</param>
        /// <param name="movie">The movie associated with the ticket.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the ticket type is not found in the configuration.</exception>
        protected Ticket(string ticketType, Movie movie) 
            : base(GetPriceInPence(ticketType)) // Set price from configuration
        {
            _ticketType = ticketType;
            _movie = movie;
        }

        /// <summary>
        /// Returns a string representation of the ticket.
        /// </summary>
        public override string ToString()
        {
            return $"{_ticketType} Ticket for {_movie}";
        }
    }

    /// <summary>
    /// Represents a standard ticket in the cinema system.
    /// </summary>
    public class StandardTicket : Ticket
    {
        /// <summary>
        /// Initializes a new instance of the StandardTicket class.
        /// </summary>
        /// <param name="movie">The movie associated with the ticket.</param>
        public StandardTicket(Movie movie) 
            : base("Standard", movie)
        {
        }
    }

    /// <summary>
    /// Represents a premium ticket in the cinema system.
    /// </summary>
    public class PremiumTicket : Ticket
    {
        /// <summary>
        /// Initializes a new instance of the PremiumTicket class.
        /// </summary>
        /// <param name="movie">The movie associated with the ticket.</param>
        public PremiumTicket(Movie movie) 
            : base("Premium", movie)
        {
        }
    }
} 