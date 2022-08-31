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
        private string owner;

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
        public string Owner 
        {
            get { return owner; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{Owner} can't be null");
                }
                
                if (value.Trim() == string.Empty)
                {
                    throw new ArgumentException($"{nameof(Owner)} must have valid text.");
                }

                if (IsOwnerNameValid(value))
                {
                    owner = value;
                }

                else
                {
                    throw new ArgumentException($"{nameof(Owner)} can be up to 20 characters, A-Z/spaces only.");
                }
            } 
        }

        /// <summary>
        /// Checks if Owner name is less than equal to 20 characters, A-Z and
        /// white space characters are allowed.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool IsOwnerNameValid(string ownerName)
        {


            char[] validCharacters = {'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 
                'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's',
                'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z' };

            const int MaxLengthOwnerName = 20;

            if (ownerName.Length > MaxLengthOwnerName)
            {
                return false;
            }

            foreach(char letter in ownerName)
            {
                if (letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
            }

            return true;
        }

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
            if (amount <= 0)
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
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} must be greater than 0");
            }
            Balance -= amount;
            return Balance;
        }
    }
}
