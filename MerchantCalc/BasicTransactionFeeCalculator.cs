using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class BasicTransactionFeeCalculator : ITransactionFeeCalculator
    {
        public double GetTransactionFee(double Amount)
        {
            // No definition of what transatction fee should be in Epic MOBILEPAY-1, therefore returning calculation of 1%
            return Amount * 1.0 / 100;
        }
    }
}
