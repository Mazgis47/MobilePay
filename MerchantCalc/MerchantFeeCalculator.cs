using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.Data;
using MobilePay.MerchantCalc.Services;

namespace MobilePay.MerchantCalc
{
    public class MerchantFeeCalculator : IMerchantFeeCalculator
    {
        private ITransactionDataProviderService _transactionDataProviderService;
        private ITransactionFeeCalculator _transactionFeeCalculator;
        private IDisplayService _displayService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transactionDataProviderService">Data provider service implemenation</param>
        /// <param name="transactionFeeCalculator">Transaction fee calculator implementation</param>
        /// <param name="displayService">Display service implementation</param>
        public MerchantFeeCalculator(ITransactionDataProviderService transactionDataProviderService, 
            ITransactionFeeCalculator transactionFeeCalculator,
            IDisplayService displayService)
        {
            _transactionDataProviderService = transactionDataProviderService;
            _transactionFeeCalculator = transactionFeeCalculator;
            _displayService = displayService;
        }

        /// <summary>
        /// Calculates fees for all transactions, invokes display service to show transaction fee
        /// </summary>
        public void CalculateFees()
        {
            foreach (var transaction in _transactionDataProviderService.GetTransactions())
            {
                var transactionFee = new TransactionFee(transaction, _transactionFeeCalculator);
                _displayService.Display(transactionFee.GetFeeInfo());
            }
        }
    }
}
