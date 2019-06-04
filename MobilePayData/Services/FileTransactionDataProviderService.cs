using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.Data
{
    /// <summary>
    /// Reads transactions from file
    /// </summary>
    public class FileTransactionDataProviderService : ITransactionDataProviderService
    {
        private string _transactionsFileName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transactionsFileName">Takes file name to read transactions from</param>
        public FileTransactionDataProviderService(string transactionsFileName)
        {
            _transactionsFileName = transactionsFileName;
        }

        /// <summary>
        /// Handles read of transactions
        /// </summary>
        /// <returns>List of transactions</returns>
        public IEnumerable<Transaction> GetTransactions()
        {
            try
            {
                return GetTransactionsFromFile();
            }
            catch(IOException ex)
            {
                Console.WriteLine($"Error occured while reading from {_transactionsFileName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Yields transactions that a read from file
        /// </summary>
        /// <returns>Transaction enumeration</returns>
        private IEnumerable<Transaction> GetTransactionsFromFile()
        {
            using (StreamReader sr = new StreamReader(_transactionsFileName))
            {
                // Read the file string by string, and send transaction back as required.
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    yield return Transaction.GetTransaction(line);
                }
            }
        }
    }
}
