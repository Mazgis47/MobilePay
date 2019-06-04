using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Entities;

namespace MobilePay.Data
{
    public class MemoryTransactionDataProviderService : ITransactionDataProviderService
    {
        private IEnumerable<string> _transactionLineList;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transactionsFileName">Takes list of transactions string list</param>
        public MemoryTransactionDataProviderService(IEnumerable<string> transactionLineList)
        {
            _transactionLineList = transactionLineList;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            foreach (var transactionLine in _transactionLineList)
            {
                yield return Transaction.GetTransaction(transactionLine);
            }
        }
    }
}
