using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void ShouldCalculateByProvidedFee()
        {
            var basicTransactionFeeCalculator = new BasicTransactionFeeCalculator(2);
            Assert.AreEqual(basicTransactionFeeCalculator.GetTransactionFee("Any", 100), 2);
        }

        [TestMethod]
        public void ShouldCalculateDiscountForProvidedFee()
        {
            var discountTransactionFeeCalculator = new DiscountTransactionFeeCalculator(new BasicTransactionFeeCalculator(1)
                            , new Dictionary<string, double>() { { "DISCOUNTMERCHANT", 10 } });
            Assert.AreEqual(discountTransactionFeeCalculator.GetTransactionFee("DISCOUNTMERCHANT", 120), 1.08);
        }

        [TestMethod]
        public void ShouldNotCalculateDiscountForProvidedFee()
        {
            var discountTransactionFeeCalculator = new DiscountTransactionFeeCalculator(new BasicTransactionFeeCalculator(1)
                            , new Dictionary<string, double>() { { "DISCOUNTMERCHANT", 10 } });
            Assert.AreEqual(discountTransactionFeeCalculator.GetTransactionFee("ANY_OTHER", 120), 1.20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Please provide valid baseTransactionFeeCalculator")]
        public void ShouldThrowError()
        {
            var discountTransactionFeeCalculator = new DiscountTransactionFeeCalculator(null
                            , new Dictionary<string, double>() { { "DISCOUNTMERCHANT", 10 } });
            discountTransactionFeeCalculator.GetTransactionFee("ANY_OTHER", 120);
        }
    }
}
