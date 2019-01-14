using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        public static void SendMail()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("DotNetProject5779SendMessage@gmail.com", "dotNet5779"),
                EnableSsl = true
            };
            client.Send("DotNetProject5779SendMessage@gmail.com", "hodaya30hn@gmail.com", "test", "This Is A Test Of Program");
        }

        static void Main(string[] args)
        {

            try
            {


                // SendMail();
                // System.Console.WriteLine( DAL.Extensions.CalculateMD5Hash("12345674"));

                //Tester t = new Tester();
                //t.ID = "12345674";
                //t.FirstName = "mi";
                //t.LastName = "amor";
                //t.BirthDate = new DateTime(1979, 6, 3);
                //BL.FactorySingletonBL.Current.AddTester(t);
                //Test t = new Test();

                //BL.FactorySingletonBL.Current.AddTest(t, testerID, traineeID);


            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadKey();
        }
    }
}
