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

        [TestMethod]
        public void ShouldCalculateDiscountForProvidedFee()
        {
            var discountTransactionFeeCalculator = new DiscountTransactionFeeCalculator(new BasicTransactionFeeCalculator(1)
                            , new Dictionary<string, double>() { { "DISCOUNTMERCHANT", 10 } });
            Assert.AreEqual(discountTransactionFeeCalculator.GetTransactionFee(new Transaction
            {
                MerchantName = "DISCOUNTMERCHANT",
                Amount = 120
            }), 1.08);
        }

        [TestMethod]
        public void ShouldCalculateDiscountForProvidedFee20()
        {
            var discountTransactionFeeCalculator = new DiscountTransactionFeeCalculator(new BasicTransactionFeeCalculator(1)
                            , new Dictionary<string, double>() { { "DISCOUNTMERCHANT", 20 } });
            Assert.AreEqual(discountTransactionFeeCalculator.GetTransactionFee(new Transaction
            {
                MerchantName = "DISCOUNTMERCHANT",
                Amount = 120
            }), 0.96);
        }

        [TestMethod]
        public void ShouldNotCalculateDiscountForProvidedFee()
        {
            var discountTransactionFeeCalculator = new DiscountTransactionFeeCalculator(new BasicTransactionFeeCalculator(1)
                            , new Dictionary<string, double>() { { "DISCOUNTMERCHANT", 10 } });
            Assert.AreEqual(discountTransactionFeeCalculator.GetTransactionFee(new Transaction
            {
                MerchantName = "ANY_OTHER",
                Amount = 120
            }), 1.20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Please provide valid baseTransactionFeeCalculator")]
        public void ShouldThrowError()
        {
            var discountTransactionFeeCalculator = new DiscountTransactionFeeCalculator(null
                            , new Dictionary<string, double>() { { "DISCOUNTMERCHANT", 10 } });
            discountTransactionFeeCalculator.GetTransactionFee(new Transaction
            {
                MerchantName = "DISCOUNTMERCHANT",
                Amount = 120
            });
        }

        [TestMethod]
        public void ShouldCalculateFixedFeeForProvidedFee()
        {
            var fixedFeeTransactionFeeCalculator = new FixedFeeTransactionFeeCalculator(new BasicTransactionFeeCalculator(1), 29);

            // First transaction in the month for MERCHANT1
            var firstTransactionInMonthMerchant1 = new Transaction
            {
                TransactionDate = new DateTime(2018, 09, 02),
                MerchantName = "MERCHANT1",
                Amount = 120
            };
            Assert.AreEqual(fixedFeeTransactionFeeCalculator.GetTransactionFee(firstTransactionInMonthMerchant1), 30.20);

            // First transaction in the month for MERCHANT2
            var firstTransactionInMonthMerchant2 = new Transaction
            {
                TransactionDate = new DateTime(2018, 09, 04),
                MerchantName = "MERCHANT2",
                Amount = 200
            };
            Assert.AreEqual(fixedFeeTransactionFeeCalculator.GetTransactionFee(firstTransactionInMonthMerchant2), 31.00);

            // First transaction in the another month for MERCHANT1
            var firstTransactionInAnotherMonthMerchant1 = new Transaction
            {
                TransactionDate = new DateTime(2018, 10, 22),
                MerchantName = "MERCHANT1",
                Amount = 300
            };
            Assert.AreEqual(fixedFeeTransactionFeeCalculator.GetTransactionFee(firstTransactionInAnotherMonthMerchant1), 32.00);

            // Second transaction in the another month for MERCHANT1
            var secondTransactionInAnotherMonthMerchant1 = new Transaction
            {
                TransactionDate = new DateTime(2018, 10, 29),
                MerchantName = "MERCHANT1",
                Amount = 150
            };
            Assert.AreEqual(fixedFeeTransactionFeeCalculator.GetTransactionFee(secondTransactionInAnotherMonthMerchant1), 1.50);
        }

        [TestMethod]
        public void ShouldCalculateNotIncludeFixedFeeFor0Fee()
        {
            var fixedFeeTransactionFeeCalculator = new FixedFeeTransactionFeeCalculator(new BasicTransactionFeeCalculator(1), 29);
            var firstTransactionInMonthMerchant1 = new Transaction
            {
                TransactionDate = new DateTime(2018, 09, 02),
                MerchantName = "MERCHANT1",
                Amount = 0
            };
            Assert.AreEqual(fixedFeeTransactionFeeCalculator.GetTransactionFee(firstTransactionInMonthMerchant1), 0);
        }
    }
}
