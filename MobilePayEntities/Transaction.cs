using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.Entities
{
    public class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public string MerchantName { get; set; }
        public double Amount { get; set; }

        /// <summary>
        /// Checks if transaction is valid
        /// </summary>
        /// <returns>Transaction is valid</returns>
        public bool IsValid()
        {
            return MerchantName != null && TransactionDate.Year != 0001;
        }

        /// <summary>
        /// Converts string line into Transaction object
        /// </summary>
        /// <param name="line">Line to convert</param>
        /// <returns>Transaction object</returns>
        public static Transaction GetTransaction(string line)
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
                return new Transaction
                {
                    TransactionDate = transactionDate,
                    MerchantName = lineSplit[1],
                    Amount = amount,
                };

            // Return empty transaction
            return new Transaction();
        }

        /// <summary>
        /// Checks if provided has at least 3 chunks
        /// </summary>
        /// <param name="lineSplit"></param>
        /// <returns>True if has 3 or more chunks, otherwise false</returns>
        private static bool IsLineChopValid(string[] lineSplit)
        {
            return lineSplit.Length >= 3;
        }
    }
}
