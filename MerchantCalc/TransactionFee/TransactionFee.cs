using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.MerchantCalc
{
    public class TransactionFee
    {
        private Transaction _transaction;
        private ITransactionFeeCalculator _transactionFeeCalculator;
        private double Fee { get { return _transactionFeeCalculator.GetTransactionFee(_transaction); } }

        public TransactionFee(Transaction transaction, ITransactionFeeCalculator transactionFeeCalculator)
        {
            _transactionFeeCalculator = transactionFeeCalculator;
            _transaction = transaction;
        }

        public string GetFeeInfo()
        {
            if (_transaction.IsValid())
                return string.Format("{0} {1}\t{2}", 
                    _transaction.TransactionDate.ToString("yyyy-MM-dd"),
                    _transaction.MerchantName, 
                    Fee.ToString("0.00", new CultureInfo("en-US")));
            return "";
        }
    }
}
