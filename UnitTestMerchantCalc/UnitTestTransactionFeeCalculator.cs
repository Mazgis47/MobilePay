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
            Assert.AreEqual(basicTransactionFeeCalculator.GetTransactionFee("Any", 100), 1);
        }
    }
}
