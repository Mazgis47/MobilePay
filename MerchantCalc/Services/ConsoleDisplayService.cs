using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay.MerchantCalc.Services
{
    public class ConsoleDisplayService : IDisplayService
    {
        public void Display(string line)
        {
            Console.WriteLine(line);
        }
    }
}
