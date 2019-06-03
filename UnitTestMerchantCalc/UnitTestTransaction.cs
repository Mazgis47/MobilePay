using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePay.MerchantCalc;

namespace UnitTestMerchantCalc
{
    [TestClass]
    public class UnitTestTransaction
    {
        [TestMethod]
        public void TestShouldMatchPrice1()
        {
            var transaction = new Transaction(new BasicTransactionFeeCalculator())
            {
                Amount = 120,
                MerchantName = "ABC",
                TransactionDate = DateTime.ParseExact("2019-01-01", "yyyy-MM-dd"
                    , CultureInfo.InvariantCulture)
            };
            Assert.AreEqual(transaction.ToString(), "2019-01-01 ABC\t1.20");
        }

        [TestMethod]
        public void ShouldBeValid()
        {
            var transaction = new Transaction(new BasicTransactionFeeCalculator())
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
            var transaction = new Transaction(new BasicTransactionFeeCalculator())
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
            var transaction = new Transaction(new BasicTransactionFeeCalculator())
            {
                Amount = 120,
                TransactionDate = DateTime.ParseExact("2019-01-01", "yyyy-MM-dd"
                    , CultureInfo.InvariantCulture)
            };
            PrivateObject obj = new PrivateObject(transaction);
            Assert.IsFalse((bool)obj.Invoke("IsValid"));
        }
    }
}
