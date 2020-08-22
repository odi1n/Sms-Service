using SMS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Work();

            Console.ReadKey();
        }

        public static async void Work()
        {
            SmsHub smsHub = new SmsHub("11140Uc7a91b48a6a9c97c02638b003f5cc6d0");
            var number = await smsHub.GetNumbersStatusAndCostHubFreeAsync();
        }
    }
}
