using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class MerchantFeeCalculator : IMerchantFeeCalculator
    {
        private ITransactionDataProviderService _transactionDataProvider;
        public MerchantFeeCalculator(ITransactionDataProviderService transactionDataProvider)
        {
            _transactionDataProvider = transactionDataProvider;
        }

        public void CalculateFees()
        {
            foreach (var transaction in _transactionDataProvider.GetTransactions())
            {
                transaction.Process();
            }
        }
    }
}
