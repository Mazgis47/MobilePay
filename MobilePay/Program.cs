using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.MerchantCalc;
using MobilePay.Data;
using MobilePay.MerchantCalc.Services;

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
                        new FileTransactionDataProviderService(GetTransactionDataFilename(args)), // Take data from file
                             new BasicTransactionFeeCalculator(1.0), // Apply Basic fee rate 1%
                             new ConsoleDisplayService()); // Display on screen
                merchantFeeCalculator.CalculateFees();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. Error was {ex.Message}");
                return 10;
            }
            return 0;
        }

        /// <summary>
        /// If specified on cmd line returns file name from argument list, otherwise - default
        /// </summary>
        /// <param name="args">cmd arguments</param>
        /// <returns>File name</returns>
        private static string GetTransactionDataFilename(string[] args)
        {
            return args.Any() ? args[0] : transactionsDataFileName;
        }
    }
}
