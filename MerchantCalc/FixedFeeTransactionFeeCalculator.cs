using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    class FixedFeeTransactionFeeCalculator : ITransactionFeeCalculator
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

        public double GetTransactionFee(string merchantName, double Amount)
        {
            if (_baseTransactionFeeCalculator == null)
                throw new ArgumentNullException("Please provide valid baseTransactionFeeCalculator");

            var baseFee = _baseTransactionFeeCalculator.GetTransactionFee(merchantName, Amount);
            //var merchantNewMonthKey = $"{merchantName}_{}";
            // Check if Merchant has discount - if so, then apply it, otherwise just return base fee
            //return _merchantDiscounts.ContainsKey(merchantName) ?
            //    baseFee * (100 - _merchantDiscounts[merchantName]) / 100
            //    : baseFee;
            throw new NotImplementedException();
        }
    }
}
