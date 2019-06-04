using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Data;

namespace MobilePay.MerchantCalc
{
    public class MerchantFeeCalculator : IMerchantFeeCalculator
    {
        private ITransactionDataProviderService _transactionDataProviderService;
        private ITransactionFeeCalculator _transactionFeeCalculator;

        public MerchantFeeCalculator(ITransactionDataProviderService transactionDataProviderService, 
            ITransactionFeeCalculator transactionFeeCalculator)
        {
            _transactionDataProviderService = transactionDataProviderService;
            _transactionFeeCalculator = transactionFeeCalculator;
        }

        public void CalculateFees()
        {
            foreach (var transaction in _transactionDataProviderService.GetTransactions())
            {
                var transactionFee = new TransactionFee(transaction, _transactionFeeCalculator);
                Console.WriteLine(transactionFee.GetFeeInfo());
            }
        }
    }
}
