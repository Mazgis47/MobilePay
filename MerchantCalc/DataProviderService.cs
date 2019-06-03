using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class DataProviderService
    {
        /// <summary>
        /// Converts string line into Transaction object
        /// </summary>
        /// <param name="line">Line to convert</param>
        /// <returns>Transaction object</returns>
        public static Transaction GetTransaction(string line)
        {
            var lineSplit = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Return empty transaction
            if (lineSplit.Length < 3)
                return new Transaction();

            // TODO More error handling
            return new Transaction
            {
                TransactionDate = DateTime.ParseExact(lineSplit[0], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                MerchantName = lineSplit[1],
                Amount = float.Parse(lineSplit[2])
            };
        }

    }
}
