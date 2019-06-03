using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public abstract class TransactionDataProviderService
    {
        protected ITransactionFeeCalculator _transactionFee;
        public TransactionDataProviderService(ITransactionFeeCalculator transactionFee)
        {
            _transactionFee = transactionFee;
        }
        /// <summary>
        /// Converts string line into Transaction object
        /// </summary>
        /// <param name="line">Line to convert</param>
        /// <returns>Transaction object</returns>
        public Transaction GetTransaction(string line)
        {
            var lineSplit = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            DateTime transactionDate;
            double amount;
            if (IsLineChopValid(lineSplit)
                    && DateTime.TryParseExact(lineSplit[0]
                        , "yyyy-MM-dd"
                        , CultureInfo.InvariantCulture
                        , DateTimeStyles.None
                        , out transactionDate)
                    && double.TryParse(lineSplit[2], out amount))
                return new Transaction(_transactionFee)
                {
                    TransactionDate = transactionDate,
                    MerchantName = lineSplit[1],
                    Amount = amount,
                };

            // Return empty transaction
            return new Transaction(null);
        }

        private bool IsLineChopValid(string[] lineSplit)
        {
            return lineSplit.Length >= 3;
        }

    }
}
