using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePay.MerchantCalc;
using MobilePay.Entities;

namespace UnitTestMobilePayMerchantCalc
{
    [TestClass]
    public class UnitTestTransactionFeeCalculator
    {
        [TestMethod]
        public void ShouldCalculateByDefaultFee()
        {
            var basicTransactionFeeCalculator = new BasicTransactionFeeCalculator();
            Assert.AreEqual(basicTransactionFeeCalculator.GetTransactionFee(new Transaction { MerchantName = "Any", Amount = 100 }), 1);
        }

        [TestMethod]
        public void ShouldCalculateByProvidedFee()
        {
            var basicTransactionFeeCalculator = new BasicTransactionFeeCalculator(2);
            Assert.AreEqual(basicTransactionFeeCalculator.GetTransactionFee(new Transaction { MerchantName = "Any", Amount = 100 }), 2);
        }

    }
}
