using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    /// <summary>
    /// Reads transactions from file
    /// </summary>
    public class FileTransactionDataProviderService : TransactionDataProviderService, ITransactionDataProviderService
    {
        private string _transactionsFileName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transactionsFileName">Takes file name to read transactions from</param>
        public FileTransactionDataProviderService(string transactionsFileName, ITransactionFeeCalculator transactionFee) :base(transactionFee)
        {
            _transactionsFileName = transactionsFileName;
        }

        /// <summary>
        /// Yields transactions that a read from file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transaction> GetTransactions()
        {
            using (StreamReader sr = new StreamReader(_transactionsFileName))
            {
                // Read the file string by string, and send transaction back as required.
                while (sr.Peek() >= 0)
                {
                    String line = sr.ReadLine();
                    //throw new NotImplementedException();
                    yield return GetTransaction(line);
                }
            }
        }

    }
}
