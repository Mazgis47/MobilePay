using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.MerchantCalc;

namespace MobilePay
{
    class Program
    {
        static void Main(string[] args)
        {
            var merchantFeeCalculator = new MerchantFeeCalculator(new FileTransactionDataProviderService(@"..\..\..\TransactionData\transactions.txt"));
            merchantFeeCalculator.CalculateFees();
        }
    }
}
