using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePay.Entities;

namespace UnitTestMobilePayEntities
{
    [TestClass]
    public class UnitTestTransaction
    {
        [TestMethod]
        public void ShouldBeValid()
        {
            var transaction = new Transaction
            {
                Amount = 120,
                MerchantName = "ABC",
                TransactionDate = DateTime.ParseExact("2019-01-01", "yyyy-MM-dd"
                    , CultureInfo.InvariantCulture)
            };
            PrivateObject obj = new PrivateObject(transaction);
            Assert.IsTrue((bool)obj.Invoke("IsValid"));
        }

        [TestMethod]
        public void ShouldNotBeValidNoDate()
        {
            var transaction = new Transaction
            {
                Amount = 120,
                MerchantName = "ABC"
            };
            PrivateObject obj = new PrivateObject(transaction);
            Assert.IsFalse((bool)obj.Invoke("IsValid"));
        }

        [TestMethod]
        public void ShouldNotBeValidNoName()
        {
            var transaction = new Transaction
            {
                Amount = 120,
                TransactionDate = DateTime.ParseExact("2019-01-01", "yyyy-MM-dd"
                    , CultureInfo.InvariantCulture)
            };
            PrivateObject obj = new PrivateObject(transaction);
            Assert.IsFalse((bool)obj.Invoke("IsValid"));
        }

        [TestMethod]
        public void ShouldCreateValidTransactionFromString()
        {
            var transaction = Transaction.GetTransaction("2018-09-30 CIRCLE_K 100");
            PrivateObject obj = new PrivateObject(transaction);
            Assert.IsTrue((bool)obj.Invoke("IsValid"));
            Assert.AreEqual(transaction.TransactionDate.Year, 2018);
            Assert.AreEqual(transaction.TransactionDate.Month, 09);
            Assert.AreEqual(transaction.TransactionDate.Day, 30);
            Assert.AreEqual(transaction.MerchantName, "CIRCLE_K");
            Assert.AreEqual(transaction.Amount, 100);
        }

        [TestMethod]
        public void ShouldCreateInvalidTransactionFromStringNoMerchantName()
        {
            var transaction = Transaction.GetTransaction("2018-09-30 100");
            PrivateObject obj = new PrivateObject(transaction);
            Assert.IsFalse((bool)obj.Invoke("IsValid"));
        }

        [TestMethod]
        public void ShouldCreateInvalidTransactionFromStringNoDate()
        {
            var transaction = Transaction.GetTransaction("TELIA 100");
            PrivateObject obj = new PrivateObject(transaction);
            Assert.IsFalse((bool)obj.Invoke("IsValid"));
        }
    }
}
