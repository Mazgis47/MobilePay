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
        public FixedFeeTransactionFeeCalculator(ITransactionFeeCalculator baseTransactionFeeCalculator, double fixedFee)
        {
            _baseTransactionFeeCalculator = baseTransactionFeeCalculator;
            _fixedFee = fixedFee;
            _firstTransactionInMonth = new Dictionary<string, bool>();
        }

        public double GetTransactionFee(Transaction transaction)
        {
            if (_baseTransactionFeeCalculator == null)
                throw new ArgumentNullException("Please provide valid baseTransactionFeeCalculator");

            var baseFee = _baseTransactionFeeCalculator.GetTransactionFee(transaction);
            var merchantNewMonthKey = $"{transaction.MerchantName}_{transaction.TransactionDate.Month}";
            
            // Check if Merchant already paid this month - if so, then only apply base fee
            if (_firstTransactionInMonth.ContainsKey(merchantNewMonthKey))
                return baseFee;

            // Mark monthly fee for this merchant and add fixed fee. 
            // TODO: remove old entries for this merchant from dictionary if too many.
            _firstTransactionInMonth.Add(merchantNewMonthKey, true);
            return baseFee + _fixedFee;
        }
    }
}
