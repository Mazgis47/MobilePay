using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    class MemoryTransactionDataProviderService : TransactionDataProviderService, ITransactionDataProviderService
    {
        private IEnumerable<string> _transactionsList;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transactionsFileName">Takes list of transactions string list</param>
        public MemoryTransactionDataProviderService(IEnumerable<string> transactionsList, ITransactionFeeCalculator transactionFee) : base(transactionFee)
        {
            _transactionsList = transactionsList;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
