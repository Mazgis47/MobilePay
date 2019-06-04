using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.MerchantCalc
{
    public class BasicTransactionFeeCalculator : ITransactionFeeCalculator
    {
        private double _fee;
        public BasicTransactionFeeCalculator()
        {
            // No definition of what transatction fee should be in Epic MOBILEPAY-1, therefore we set as default to 1%
            _fee = 1.0;
        }
        public BasicTransactionFeeCalculator(double fee)
        {
            _fee = fee;
        }
        public double GetTransactionFee(Transaction transaction)
        {
            return transaction.Amount * _fee / 100;
        }
    }
}
