﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize] // must be public not private
        public void CreateDefaultAccount()
        {
            acc = new Account("J Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            // Account acc = new ("J Doe");
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert
            // Arrange
            // Account acc = new("J Doe");

            double depositAmount = 100;
            double expectedReturnBalance = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturnBalance, returnValue);


        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [TestCategory("Deposit")]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Account acc = new Account("J. Doe");
            // double invalidDepositAmount = -1;

            // Assert => Account
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));

            
        }

        // Withdrawing a positive amount. Retunrs a updated balance.
        // Withdrawing 0. Throws ArgumentOutOfRange exception.
        // Withdrawing a negative amount.Throws ArgumentOutOfRange exception.
        // Withdrawing more than is in the balance. Throws ArgumentException.
        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_PostiveAmount_DecreasesBalance()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(withdrawalAmount, actualBalance);
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(100, .99)]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double initialDeposit, double withdrawalAmount)
        {
            // Arrange
            double expectedBalance = initialDeposit - withdrawalAmount;
            acc.Deposit(initialDeposit);

            // Act
            double returnBalance = acc.Withdraw(withdrawalAmount);

            // Assert
            Assert.AreEqual(expectedBalance, returnBalance);
            
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-0.01)]
        [DataRow(-1000)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawAmount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        [DataRow(1000)]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsnArgumentException(double withdrawAmount)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("     ")]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException(String badName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = badName);
        }

        [TestMethod]
        [DataRow("Edgar")]
        [DataRow("Edgar Cruz")]
        [DataRow("EdgardoGuillermoCruz")]
        
        public void Owner_SetAsUpTo20Characters_SetSuccessfully(string OwnerName)
        {
            acc.Owner = OwnerName;
            Assert.AreEqual(OwnerName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Edgardo Guillermo Cruz Jr")]
        [DataRow("Edgar 9th")]
        [DataRow("!@#$%^&*()_+")]
        [DataRow("-_-")]
        public void Owner_InvalidOwnerName_ThrowsArgumentExecption(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}