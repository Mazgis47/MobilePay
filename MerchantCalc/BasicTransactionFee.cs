using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    class BasicTransactionFee : ITransactionFee
    {
        public double GetTransactionFee()
        {
            return 1.0;
        }
    }
}
