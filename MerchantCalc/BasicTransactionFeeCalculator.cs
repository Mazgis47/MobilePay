using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class BasicTransactionFeeCalculator : ITransactionFeeCalculator
    {
        private double _fee;
        public BasicTransactionFeeCalculator()
        {
            // No definition of what transatction fee should be in Epic MOBILEPAY-1, therefore fee is 1%
            _fee = 1.0;
        }
        public BasicTransactionFeeCalculator(double fee)
        {
            // No definition of what transatction fee should be in Epic MOBILEPAY-1, therefore fee is 1%
            _fee = fee;
        }
        public double GetTransactionFee(string merchantName, double Amount)
        {
            return Amount * _fee / 100;
        }
    }
}
