using System;

namespace Capstone
{
    /// <summary>
    /// Represents a customer in the cinema system.
    /// </summary>
    public class Customer
    {
        private string _firstName;
        private string _surname;
        private string _email;
        private LoyaltyScheme _loyaltyScheme;

        /// <summary>
        /// Gets the customer's first name.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
        }

        /// <summary>
        /// Gets the customer's surname.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
        }

        /// <summary>
        /// Gets the customer's email address.
        /// </summary>
        public string Email
        {
            get { return _email; }
        }

        /// <summary>
        /// Gets or sets the customer's loyalty scheme.
        /// </summary>
        public LoyaltyScheme LoyaltyScheme
        {
            get { return _loyaltyScheme; }
            set { _loyaltyScheme = value; }
        }

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        /// <param name="firstName">The customer's first name.</param>
        /// <param name="surname">The customer's surname.</param>
        /// <param name="email">The customer's email address.</param>
        public Customer(string firstName, string surname, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName), "First name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentNullException(nameof(surname), "Surname cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty.");

            _firstName = firstName;
            _surname = surname;
            _email = email;
        }

        /// <summary>
        /// Returns a string representation of the customer.
        /// </summary>
        public override string ToString()
        {
            return $"{_firstName} {_surname} ({_email})";
        }
    }
} 