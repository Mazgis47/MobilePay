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
            const string transactionsDataFileName = @"..\..\..\TransactionData\transactions.txt";
            try
            {
                var merchantFeeCalculator = new MerchantFeeCalculator(new FileTransactionDataProviderService(transactionsDataFileName,
                        new BasicTransactionFeeCalculator()
                      ));
                merchantFeeCalculator.CalculateFees();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong. Error was {ex.Message}");
            }
        }
    }
}
