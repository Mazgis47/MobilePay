using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class MerchantFeeCalculator : IMerchantFeeCalculator
    {
        private ITransactionDataProviderService _transactionDataProviderService;
        public MerchantFeeCalculator(ITransactionDataProviderService transactionDataProviderService)
        {
            _transactionDataProviderService = transactionDataProviderService;
        }

        public void CalculateFees()
        {
            foreach (var transaction in _transactionDataProviderService.GetTransactions())
            {
                transaction.Process();
            }
        }
    }
}
