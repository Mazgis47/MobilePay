using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.MerchantCalc
{
    public class FixedFeeTransactionFeeCalculator : ITransactionFeeCalculator
    {
        ITransactionFeeCalculator _baseTransactionFeeCalculator;
        double _fixedFee;
        Dictionary<string, bool> _firstTransactionInMonth;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseTransactionFeeCalculator">Previous Transaction Fee Calculator implementation</param>
        /// <param name="fixedFee">Fixed monthly fee</param>
        public FixedFeeTransactionFeeCalculator(ITransactionFeeCalculator baseTransactionFeeCalculator, double fixedFee)
        {
            _baseTransactionFeeCalculator = baseTransactionFeeCalculator;
            _fixedFee = fixedFee;
            _firstTransactionInMonth = new Dictionary<string, bool>();
        }

        /// <summary>
        /// Calculates Transaction fee - applies Previous (base) fee and Monthly fixed fee
        /// </summary>
        /// <param name="transaction">Transaction that requires fee calculation</param>
        /// <returns>Calculated transaction fee</returns>
        public double GetTransactionFee(Transaction transaction)
        {
            if (_baseTransactionFeeCalculator == null)
                throw new ArgumentNullException("Please provide valid baseTransactionFeeCalculator");

            var baseFee = _baseTransactionFeeCalculator.GetTransactionFee(transaction);
            var merchantNewMonthKey = $"{transaction.MerchantName}_{transaction.TransactionDate.Month}";
            
            // Check if Merchant already paid this month or fee = 0, if so, then only apply base fee
            if (_firstTransactionInMonth.ContainsKey(merchantNewMonthKey) || baseFee == 0)
                return baseFee;

            // Mark monthly fee for this merchant and add fixed fee. 
            _firstTransactionInMonth.Add(merchantNewMonthKey, true);
            return baseFee + _fixedFee;
        }
    }
}
