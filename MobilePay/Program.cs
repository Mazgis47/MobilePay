using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePay.MerchantCalc;
using MobilePay.Data;

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
                        new FixedFeeTransactionFeeCalculator(   // Apply fixed fee and wrap...
                            new DiscountTransactionFeeCalculator( // Apply Discount by Merchant and wrap...
                                new BasicTransactionFeeCalculator(1.0), // Apply Basic fee rate 1%
                                new Dictionary<string, double>() { { "TELIA", 10 }, { "CIRCLE_K", 20 } }), // Provide discounts by Merchants
                            29.0) // Provide fixed monthly fee
                     );
                merchantFeeCalculator.CalculateFees();
            }
            catch (Exception ex)
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
