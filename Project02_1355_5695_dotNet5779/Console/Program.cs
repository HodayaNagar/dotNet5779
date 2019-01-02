using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string addrs1 = "גולי דמשק 8 נס ציונה";
            string addrs2 = "ההגנה 25 רחובות";
            try
            {
                var provider = new BL.BL_imp();
                double distance = provider.Distance(address1: addrs1, address2: addrs2);
                System.Console.WriteLine(distance.ToString("N4"));
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadKey();
        }
    }
}
