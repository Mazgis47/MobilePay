using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class MemoryTransactionDataProviderService : TransactionDataProviderService, ITransactionDataProviderService
    {
        private IEnumerable<string> _transactionLineList;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transactionsFileName">Takes list of transactions string list</param>
        public MemoryTransactionDataProviderService(IEnumerable<string> transactionLineList, ITransactionFeeCalculator transactionFee) : base(transactionFee)
        {
            _transactionLineList = transactionLineList;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            foreach (var transactionLine in _transactionLineList)
            {
                yield return GetTransaction(transactionLine);
            }
        }
    }
}
