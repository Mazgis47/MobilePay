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
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public BasicTransactionFeeCalculator()
        {
            // No definition of what transatction fee should be in Epic MOBILEPAY-1, therefore we set as default to 1%
            _fee = 1.0;
        }
        /// <summary>
        /// Sets Transaction Percentage Fee 
        /// </summary>
        /// <param name="fee">Transaction Percentage Fee</param>
        public BasicTransactionFeeCalculator(double fee)
        {
            _fee = fee;
        }
        
        /// <summary>
        /// Calculates transaction fee according to Transaction Amount and percentage fee 
        /// </summary>
        /// <param name="transaction">Transaction that requires fee calculation</param>
        /// <returns>Calculated transaction fee</returns>
        public double GetTransactionFee(Transaction transaction)
        {
            return transaction.Amount * _fee / 100;
        }
    }
}
