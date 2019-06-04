using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public interface ITransactionFeeCalculator
    {
        double GetTransactionFee(string merchantName, double Amount);
    }
}
