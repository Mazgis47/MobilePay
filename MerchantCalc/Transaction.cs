using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc
{
    public class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public string MerchantName { get; set; }
        public double Amount { get; set; }
        private double Fee { get { return Amount * 0.01; } }
        public void Process()
        {
            if (IsValid())
                Console.WriteLine(string.Format("{0} {1}\t{2}", TransactionDate.ToString("yyyy-MM-dd"), MerchantName, Fee.ToString("0.00", new CultureInfo("en-US"))));
            else
                Console.WriteLine();
        }
        private bool IsValid()
        {
            return MerchantName != null && TransactionDate != null;
        }
    }
}
