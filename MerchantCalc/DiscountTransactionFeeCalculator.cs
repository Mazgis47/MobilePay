using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double GetTransactionFee(string merchantName, double Amount)
        {
            if (_baseTransactionFeeCalculator == null)
                throw new ArgumentNullException("Please provide valid baseTransactionFeeCalculator");

            var baseFee = _baseTransactionFeeCalculator.GetTransactionFee(merchantName, Amount);
            
            // Check if Merchant has discount - if so, then apply it, otherwise just return base fee
            return _merchantDiscounts != null && _merchantDiscounts.ContainsKey(merchantName) ?
                baseFee * (100 -_merchantDiscounts[merchantName]) / 100
                : baseFee;
        }
    }
}
