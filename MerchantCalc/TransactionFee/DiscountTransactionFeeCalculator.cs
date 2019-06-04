using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.MerchantCalc
{
    public class DiscountTransactionFeeCalculator : ITransactionFeeCalculator
    {
        ITransactionFeeCalculator _baseTransactionFeeCalculator;
        Dictionary<string, double> _merchantDiscounts;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="baseTransactionFeeCalculator">Previous Transaction Fee Calculator implementation</param>
        /// <param name="merchantDiscounts">Dictionary of Merchant/Discount pairs</param>
        public DiscountTransactionFeeCalculator(ITransactionFeeCalculator baseTransactionFeeCalculator, Dictionary<string, double> merchantDiscounts)
        {
            _baseTransactionFeeCalculator = baseTransactionFeeCalculator;
            _merchantDiscounts = merchantDiscounts;
        }

        /// <summary>
        /// Calculates Transaction fee - applies Previous (base) fee and Merchant discount if applicable
        /// </summary>
        /// <param name="transaction">Transaction that requires fee calculation</param>
        /// <returns>Calculated transaction fee</returns>
        public double GetTransactionFee(Transaction transaction)
        {
            if (_baseTransactionFeeCalculator == null)
                throw new ArgumentNullException("Please provide valid baseTransactionFeeCalculator");

            var baseFee = _baseTransactionFeeCalculator.GetTransactionFee(transaction);
            
            // Check if Merchant has discount - if so, then apply it, otherwise just return base fee
            return _merchantDiscounts != null && _merchantDiscounts.ContainsKey(transaction.MerchantName) ?
                baseFee * (100 -_merchantDiscounts[transaction.MerchantName]) / 100
                : baseFee;
        }
    }
}
