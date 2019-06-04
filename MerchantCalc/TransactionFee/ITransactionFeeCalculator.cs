using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.MerchantCalc
{
    public interface ITransactionFeeCalculator
    {
        double GetTransactionFee(Transaction transactionFee);
    }
}
