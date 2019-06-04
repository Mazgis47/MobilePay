using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.MerchantCalc
{
    /// <summary>
    /// Ties transaction with transaction fee calculator
    /// </summary>
    public class TransactionFee
    {
        private Transaction _transaction;
        private ITransactionFeeCalculator _transactionFeeCalculator;
        private double FeeAmount { get { return _transactionFeeCalculator.GetTransactionFee(_transaction); } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transaction">Transaction</param>
        /// <param name="transactionFeeCalculator">Transaction Fee Calculator implementation</param>
        public TransactionFee(Transaction transaction, ITransactionFeeCalculator transactionFeeCalculator)
        {
            _transactionFeeCalculator = transactionFeeCalculator;
            _transaction = transaction;
        }

        /// <summary>
        /// Gets Fee information
        /// </summary>
        /// <returns>String having Transaction Date, Merchant Name and Transaction Fee amount</returns>
        public string GetFeeInfo()
        {
            if (_transaction.IsValid())
                return string.Format("{0} {1}\t{2}", 
                    _transaction.TransactionDate.ToString("yyyy-MM-dd"),
                    _transaction.MerchantName, 
                    FeeAmount.ToString("0.00", new CultureInfo("en-US")));
            return "";
        }
    }
}
