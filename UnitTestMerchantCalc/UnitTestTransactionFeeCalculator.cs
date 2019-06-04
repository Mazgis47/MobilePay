using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePay.MerchantCalc;

namespace UnitTestMerchantCalc
{
    [TestClass]
    public class UnitTestTransactionFeeCalculator
    {
        [TestMethod]
        public void ShouldCalculateByDefaultFee()
        {
            var basicTransactionFeeCalculator = new BasicTransactionFeeCalculator();
            Assert.AreEqual(basicTransactionFeeCalculator.GetTransactionFee(new Transaction(basicTransactionFeeCalculator) { MerchantName = "Any", Amount = 100 } ), 1);
        }
        [TestMethod]
        public void ShouldCalculateByProvidedFee()
        {
            var basicTransactionFeeCalculator = new BasicTransactionFeeCalculator(2);
            Assert.AreEqual(basicTransactionFeeCalculator.GetTransactionFee(new Transaction(basicTransactionFeeCalculator) { MerchantName = "Any", Amount = 100 }), 2);
        }
    }
}
