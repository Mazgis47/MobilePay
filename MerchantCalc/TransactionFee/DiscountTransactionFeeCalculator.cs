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
        public DiscountTransactionFeeCalculator(ITransactionFeeCalculator baseTransactionFeeCalculator, Dictionary<string, double> merchantDiscounts)
        {
            _baseTransactionFeeCalculator = baseTransactionFeeCalculator;
            _merchantDiscounts = merchantDiscounts;
        }

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
