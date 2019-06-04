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
        const string transactionsDataFileName = @"..\..\..\TransactionData\transactions.txt";
        static int Main(string[] args)
        {
            try
            {
                var merchantFeeCalculator = new MerchantFeeCalculator(
                        new FileTransactionDataProviderService(GetTransactionDataFilename(args),
                        new BasicTransactionFeeCalculator()
                      ));
                merchantFeeCalculator.CalculateFees();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong. Error was {ex.Message}");
                return 10;
            }
            return 0;
        }

        private static string GetTransactionDataFilename(string[] args)
        {
            return args.Any() ? args[0] : transactionsDataFileName;
        }
    }
}
