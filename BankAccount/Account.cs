using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customer's bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates an account with a specific owner
        /// and a balance of zero.
        /// </summary>
        /// <param name="accOwner">The customer's full name that owns the account</param> 
        public Account(string accOwner)
        {
            Owner = accOwner;
            
        }

        /// <summary>
        /// The account holders full name (First and Last)
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The amount of money currently in the account.
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Add specified amount of money to the account.
        /// Returns the new balance
        /// </summary>
        /// <param name="amount">Add a positive amount to deposit.</param>
        /// <returns>The new Balance after deposit.</returns>
        
        public double Deposit(double amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amount)} must be gretaer than 0");
            }
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Subtract a specified amount of money from the account.
        /// </summary>
        /// <param name="amount">The positive amount of money to be taken from the balance.</param>
        /// <returns> Returns updated balance after withdrawal </returns>

        public double Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException($"{nameof(amount)} can't be greater than balance.");
            }
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} must be greater than 0");
            }
            Balance -= amount;
            return Balance;
        }
    }
}
