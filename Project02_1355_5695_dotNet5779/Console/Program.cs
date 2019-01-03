using BE;
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
            //string addrs1 = "גולי דמשק 8 נס ציונה";
            //string addrs2 = "ההגנה 25 רחובות";
            try
            {
                var provider = new BL.BL_imp();
                //double distance = provider.Distance(address1: addrs1, address2: addrs2);
                //System.Console.WriteLine(distance.ToString("N4"));

                

                Tester tester = new Tester();
                tester.ID = 207109190;
                tester.FirstName = "yiska";
                tester.LastName = "ashkenazi";
                tester.BirthDate = new DateTime(1979, 6, 3);
                tester.CarSpecializtion = CarType.Private;
                tester.Seniority = 6;
               // provider.AddTester(tester);

                Trainee trainee = new Trainee();
                trainee.ID = 207915695;
                trainee.FirstName = "hodaya";
                trainee.LastName = "nagar";
                trainee.BirthDate = new DateTime(1979, 6, 4);
               // provider.AddTrainee(trainee);

                Test test = new Test();
                test.TestID = 11111111111;
                test.TesterID = tester.ID;
                test.TraineeID = trainee.ID;
                test.CarType = CarType.Private;
                provider.AddTest(test, test.TesterID, test.TraineeID);

            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadKey();
        }
    }
}
