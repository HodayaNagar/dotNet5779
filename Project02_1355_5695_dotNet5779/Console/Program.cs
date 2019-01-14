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
               // System.Console.WriteLine( DAL.Extensions.CalculateMD5Hash("318552080"));

                //Tester t = new Tester();
                //t.ID = "12345674";
                //t.FirstName = "mi";
                //t.LastName = "amor";
                //t.BirthDate = new DateTime(1979, 6, 3);
                //BL.FactorySingletonBL.Current.AddTester(t);
                Test t = new Test();
                string testerID = "318552080";
                string traineeID = "218572279";
                BL.FactorySingletonBL.Current.AddTest(t, testerID, traineeID);


            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadKey();
        }
    }
}
/*
  <Test>
    <TestID>10000000</TestID>
    <TraineeID>E446992C40B9733E3A08057CD32483D3</TraineeID>
    <TesterID>3567D9902D8C4E24DEB207D5134819FD</TesterID>
    <TestTime>0001-01-01T00:00:00</TestTime>
    <Result>Passed</Result>
    <CarType>Private</CarType>
  </Test>
  */