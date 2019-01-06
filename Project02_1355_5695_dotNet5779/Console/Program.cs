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
        
            try
            {
                int[] tz = { 207915695, 207109190, 218572279, 217449495, 329140081, 330930165, 213203649, 325180693, 54379912, 200713501, 201558137, 308405356, 205631823, 203385547, 305011447 };

                #region testing
                //string addrs1 = "גולי דמשק 8 נס ציונה";
                //string addrs2 = "ההגנה 25 רחובות";
                //var provider = new BL.BL_imp();
                //double distance = provider.Distance(address1: addrs1, address2: addrs2);
                // System.Console.WriteLine(distance.ToString("N4"));
                //
                //int RunningID = 0;
                //int tRunningID = 12345674;
                //
                //
                //#region Tester data
                //
                //Tester tester;
                //for (int i = 0; i < 5; i++)
                //{
                //    tester = new Tester()
                //    {
                //        ID = tz[RunningID++],
                //        FirstName = $"Tester{i}",
                //        LastName = $"ID{tz[RunningID - 1]}",
                //        BirthDate = new DateTime(1978, 12, 12),
                //        Gender = Gender.Male,
                //        Address = new Address()
                //        {
                //            City = "jerusalem",
                //            StreetName = "Jaffa",
                //            BuildingNumber = 12,
                //        },
                //        Seniority = 15 - i,
                //        MaxWeeklyTests = 2,
                //        CarSpecializtion = CarType.Private,
                //        WorkingSchedule = new bool[Configuration.WorkingDaysInWeek, Configuration.WorkingHoursInDay]
                //        {
                //        { false, false, true, false, false, true },
                //        { false, false, false, true, true, false },
                //        { true, true, true, false, false, false },
                //        { false, false, true, false, false, false },
                //        { true, false, false, false, true, false }
                //        },
                //        MaxDistanceInKilometers = 5
                //    };
                //    try
                //    {
                //        BL.FactorySingletonBL.Current.AddTester(tester);
                //    }
                //    catch (Exception ex)
                //    {
                //        System.Console.WriteLine(ex.Message);
                //    }

                //}
                //#endregion

                //#region Trainee data

                //Trainee trainee;
                //for (int i = 0; i < 5; i++)
                //{
                //    trainee = new Trainee()
                //    {
                //        ID = tz[RunningID++],
                //        FirstName = $"Trainee{i}",
                //        LastName = $"ID{tz[RunningID - 1]}",
                //        BirthDate = new DateTime(2000, 12, 12),
                //        Gender = Gender.Male,
                //        Address = new Address()
                //        {
                //            City = "Tel Aviv",
                //            StreetName = "Hagana",
                //            BuildingNumber = 57 - i,
                //        },
                //        CarTrained = CarType.Private,
                //        GearType = GearType.Automatic,
                //        DrivingSchool = "smartdrive",
                //        DrivingInstructorFirstName = $"Instructor {tz[RunningID]}",
                //        DrivingInstructorLastName = $"of trainee ID:{i}",
                //        TotalLessonsNumber = 28
                //    };

                //    try
                //    {
                //        BL.FactorySingletonBL.Current.AddTrainee(trainee);
                //    }
                //    catch (Exception ex)
                //    {
                //        System.Console.WriteLine(ex.Message);
                //    }

                //}
                //#endregion

                //#region Test data

                //Test test;
                //for (int i = 0; i < 5; i++)
                //{
                //    test = new Test()
                //    {
                //        TestID = tRunningID++,
                //        TraineeID = tz[i + 5],
                //        TesterID = tz[i],
                //        TestTime = new DateTime(2019, 01, i + 1),
                //        StartingPoint = new Address()
                //        {
                //            City = "Ramat Gat",
                //            StreetName = "Aluf David",
                //            BuildingNumber = 187
                //        },
                //        Requirements = new Dictionary<TestCriterion, Pass>()
                //    {
                //        { TestCriterion.Distance, Pass.Passed },
                //        { TestCriterion.Mirrors, Pass.Passed },
                //        { TestCriterion.Reverse, Pass.Passed },
                //        { TestCriterion.Signals, Pass.Passed },
                //    },
                //        Result = Pass.Passed,
                //        Comments = "trainee drives too fast"
                //    };

                //    try
                //    {
                //        BL.FactorySingletonBL.Current.AddTest(test, test.TesterID, test.TraineeID);
                //    }
                //    catch (Exception ex)
                //    {
                //        System.Console.WriteLine(ex.Message);
                //    }

                //}
                //#endregion
                //System.Console.WriteLine("Testers:");
                //foreach (var item in BL.FactorySingletonBL.Current.GetAllTesters())
                //{
                //    BL.BL_imp.PrintProperty(item);
                //    System.Console.WriteLine("");
                //}
                //System.Console.WriteLine("Trainees:");
                //foreach (var item in BL.FactorySingletonBL.Current.GetAllTrainees())
                //{
                //    BL.BL_imp.PrintProperty(item);
                //    System.Console.WriteLine("");
                //}
                //System.Console.WriteLine("Tests:");
                //foreach (var item in BL.FactorySingletonBL.Current.GetAllTests())
                //{
                //    BL.BL_imp.PrintProperty(item);
                //    System.Console.WriteLine("");
                //}

                //System.Console.WriteLine(" רשימת בוחנים מכווצת לפי ההתמחות שלהם");
                //foreach (var item in provider.TestersExperty(true))
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}
                //foreach (var item in provider.TestersExperty())
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}

                //System.Console.WriteLine(" רשימת תלמידים מכווצת לפי בית ספר לנהיגה");

                //// רשימת תלמידים מכווצת לפי בית ספר לנהיגה
                //foreach (var item in provider.TraineesDrivingSchoolList(true))
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}
                //foreach (var item in provider.TraineesDrivingSchoolList())
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}

                //System.Console.WriteLine(" רשימת תלמידים מכווצת לפי מורה נהיגה");
                //foreach (var item in provider.DrivingInstructorList(true))
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}
                //foreach (var item in provider.DrivingInstructorList())
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}

                //System.Console.WriteLine(" רשימת תלמידים מכווצת לפי מספר הטסטים");
                //foreach (var item in provider.TraineeNumOfTestsList(true))
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}
                //foreach (var item in provider.TraineeNumOfTestsList())
                //{
                //    BL.BL_imp.PrintProperty(item);
                //}
                #endregion



                Tester t = new Tester()
                {
                    ID = 207915695,
                    FirstName = $"Tester{0}",
                    LastName = $"ID207915695",
                    BirthDate = new DateTime(1978, 12, 12),
                    Gender = Gender.Male,
                    Address = new Address()
                    {
                        City = "jerusalem",
                        StreetName = "Jaffa",
                        BuildingNumber = 12,
                    },
                    Seniority = 15 ,
                    MaxWeeklyTests = 2,
                    CarSpecializtion = CarType.Private,
                    WorkingSchedule = new bool[Configuration.WorkingDaysInWeek, Configuration.WorkingHoursInDay]
                        {
                        { false, false, true, false, false, true },
                        { false, false, false, true, true, false },
                        { true, true, true, false, false, false },
                        { false, false, true, false, false, false },
                        { true, false, false, false, true, false }
                        },
                    MaxDistanceInKilometers = 5
                };
                try
                {
                    BL.FactorySingletonBL.Current.AddTester(t);
                    

                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadKey();
        }
    }
}
