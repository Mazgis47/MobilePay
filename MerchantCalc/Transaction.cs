using System;
using System.Collections.Generic;
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
            if (MerchantName == null || TransactionDate == null)
                Console.WriteLine();
            else
                //Console.WriteLine($"{TransactionDate.ToString("YYYY-MM-dd")} {MerchantName}\t" + string.Format("{0}",Fee));
                Console.WriteLine(string.Format("{0} {1}\t{2:0.00}", TransactionDate.ToString("yyyy-MM-dd"), MerchantName, Fee));
        }
    }
}
