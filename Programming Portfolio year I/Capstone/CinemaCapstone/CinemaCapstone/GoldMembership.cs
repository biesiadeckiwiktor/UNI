using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone
{
    /// <summary>
    /// Represents a gold membership in the cinema system.
    /// </summary>
    public class GoldMembership : LoyaltyScheme
    {
        private static List<GoldMemberDetails> _goldMembers = new List<GoldMemberDetails>();
        private static readonly int ANNUAL_PRICE_IN_PENCE = 3000; // £30.00
        private static readonly decimal CONCESSION_DISCOUNT = 0.25m; // 25% discount
        private DateTime _expirationDate;
        private int _membershipNumber;

        private class GoldMemberDetails
        {
            public int MembershipNumber { get; private set; }
            public DateTime ExpirationDate { get; private set; }

            public GoldMemberDetails(int membershipNumber, DateTime expirationDate)
            {
                MembershipNumber = membershipNumber;
                ExpirationDate = expirationDate;
            }

            public bool IsExpired()
            {
                return DateTime.Now > ExpirationDate;
            }
        }

        /// <summary>
        /// Initializes a new instance of the GoldMembership class.
        /// </summary>
        /// <param name="member">The member to upgrade to gold membership.</param>
        public GoldMembership(LoyaltyScheme member)
        {
            _membershipNumber = member.MembershipNumber;
            _expirationDate = DateTime.Now.AddYears(1);
        }

        /// <summary>
        /// Upgrades a member to gold membership.
        /// </summary>
        /// <param name="membershipNumber">The membership number of the member to upgrade.</param>
        /// <returns>A tuple containing success status, message, and the new gold membership if successful.</returns>
        public static (bool success, string message, GoldMembership goldMembership) UpgradeToGold(int membershipNumber)
        {
            var member = GetMember(membershipNumber);
            if (member == null)
            {
                return (false, "Invalid membership number.", null);
            }

            // Check if already a gold member
            if (member is GoldMembership)
            {
                return (false, "You are already a gold member.", null);
            }

            // Create new gold membership
            var goldMembership = new GoldMembership(member);
            
            // Replace the regular member with gold member in the members list
            int index = _members.IndexOf(member);
            if (index != -1)
            {
                _members[index] = goldMembership;
            }

            return (true, "Successfully upgraded to gold membership!", goldMembership);
        }

        /// <summary>
        /// Checks if the gold membership is still valid.
        /// </summary>
        /// <returns>True if the membership is valid, false otherwise.</returns>
        public bool IsValid()
        {
            return DateTime.Now <= _expirationDate;
        }

        /// <summary>
        /// Gets the concession discount percentage.
        /// </summary>
        /// <returns>The discount percentage as a decimal.</returns>
        public decimal GetConcessionDiscount()
        {
            return IsValid() ? CONCESSION_DISCOUNT : 0m;
        }

        /// <summary>
        /// Returns a string representation of the gold membership.
        /// </summary>
        public override string ToString()
        {
            return $"Gold Membership #{_membershipNumber} (Expires: {_expirationDate:dd/MM/yyyy})";
        }

        public static bool IsGoldMember(int membershipNumber)
        {
            var goldMember = _goldMembers.FirstOrDefault(g => g.MembershipNumber == membershipNumber);
            
            if (goldMember == null)
            {
                return false;
            }

            // If membership has expired, remove it and return false
            if (goldMember.IsExpired())
            {
                _goldMembers.Remove(goldMember);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Calculates the discounted price for a concession.
        /// </summary>
        /// <param name="originalPrice">The original price in pence.</param>
        /// <returns>The discounted price in pence.</returns>
        public static decimal CalculateConcessionDiscount(decimal originalPrice)
        {
            return originalPrice * 0.75m; // 25% discount
        }

        public static void CheckAndRemoveExpiredMemberships()
        {
            var expiredMemberships = _goldMembers.Where(g => g.IsExpired()).ToList();
            foreach (var expiredMembership in expiredMemberships)
            {
                _goldMembers.Remove(expiredMembership);
            }
        }
    }
} 