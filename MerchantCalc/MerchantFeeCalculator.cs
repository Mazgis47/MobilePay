using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class MerchantFeeCalculator : IMerchantFeeCalculator
    {
        private IDataProviderService _dataProvider;
        public MerchantFeeCalculator(IDataProviderService dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public void CalculateFees()
        {
            foreach (var transaction in _dataProvider.GetTransactions())
            {
                transaction.Process();
            }
        }
    }
}
