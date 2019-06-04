using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePay.Entities;
using MobilePay.MerchantCalc;

namespace UnitTestMobilePayMerchantCalc
{
    [TestClass]
    public class UnitTestTransaction
    {
        [TestMethod]
        public void TestShouldMatchPrice1()
        {
            var transaction = new Transaction
            {
                Amount = 120,
                MerchantName = "ABC",
                TransactionDate = DateTime.ParseExact("2019-01-01", "yyyy-MM-dd"
                    , CultureInfo.InvariantCulture)
            };
            var transactionFee = new TransactionFee(transaction, new BasicTransactionFeeCalculator());
            Assert.AreEqual(transactionFee.GetFeeInfo(), "2019-01-01 ABC\t1.20");
        }
    }
}
