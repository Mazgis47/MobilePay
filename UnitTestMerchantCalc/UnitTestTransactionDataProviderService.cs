using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePay.MerchantCalc;

namespace UnitTestMerchantCalc
{
    [TestClass]
    public class UnitTestTransactionDataProviderService
    {
        [TestMethod]
        public void TestTransactionsCreated()
        {
            var transactionLineArray = new string[] { "2018-09-02 CIRCLE_K 120", "2018-09-04 TELIA    200" };
            var memoryTransactionDataProviderService = new MemoryTransactionDataProviderService(transactionLineArray,
                new BasicTransactionFeeCalculator());
            IEnumerable<Transaction> transactions = memoryTransactionDataProviderService.GetTransactions();
            Assert.IsTrue(transactions.Count() == 2);
            Assert.AreEqual(transactions.First().TransactionDate.Month, 9);
            Assert.AreEqual(transactions.Last().MerchantName, "TELIA");
            Assert.AreEqual(transactions.Last().Amount, 200);
        }
    }
}
