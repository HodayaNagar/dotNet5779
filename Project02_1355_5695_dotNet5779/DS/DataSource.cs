using BE;
using System;
using System.Collections.Generic;

namespace DS
{
    public class DataSource
    {
        public static List<Tester> testersList = new List<Tester>();
        public static List<Trainee> traineesList = new List<Trainee>();
        public static List<Test> testsList = new List<Test>();


        public static void data()
        {
            int RunningID = 10000000;
            int tRunningID = 12345674; // 12345678 - זאת תעודת זהות לא תקינה
            // אתן אמורות לבדוק תקינות תעודת זהות, לא?


            #region Tester data

            Tester tester;
            for (int i = 0; i < 10; i++)
            {
                tester = new Tester()
                {
                    ID = RunningID++,
                    FirstName = $"Tester {i}",
                    LastName = $"ID {RunningID - 1}",
                    BirthDate = new DateTime(2000, 12, 12),
                    Gender = Gender.Male,
                    Address = new Address()
                    {
                        City = "jerusalem",
                        StreetName = "Jaffa",
                        BuildingNumber = 12,
                    },
                    Seniority = 15,
                    MaxWeeklyTests = 1,
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

                testersList.Add(tester);
            }
            #endregion

            #region Trainee data

            Trainee trainee;
            for (int i = 0; i < 10; i++)
            {
                trainee = new Trainee()
                {
                    ID = RunningID++,
                    FirstName = $"Trainee{i}",
                    LastName = $"ID{RunningID - 1}",
                    BirthDate = new DateTime(2000, 12, 12),
                    Gender = Gender.Male,
                    Address = new Address()
                    {
                        City = "Tel Aviv",
                        StreetName = "Hagana",
                        BuildingNumber = 57,
                    },
                    CarTrained = CarType.Private,
                    GearType = GearType.Automatic,
                    DrivingSchool = "smartdrive",
                    DrivingInstructorFirstName = $"Instructor{i - 1050 + 1}",
                    DrivingInstructorLastName = $"of trainee ID:{i}",
                    TotalLessonsNumber = 28
                };

                traineesList.Add(trainee);
            }
            #endregion

            #region Test data

            Test test;
            for (int i = 0; i < 10; i++)
            {
                test = new Test()
                {
                    TestID = tRunningID++,
                    TraineeID = i + tRunningID,
                    TesterID = i + tRunningID,
                    TestTime = new DateTime(2019, 01, i + 1),
                    StartingPoint = new Address()
                    {
                        City = "Ramat Gat",
                        StreetName = "Aluf David",
                        BuildingNumber = 187
                    },
                    Requirements = new Dictionary<TestCriterion, Pass>()
                    {
                        { TestCriterion.Distance, Pass.Passed },
                        { TestCriterion.Mirrors, Pass.Passed },
                        { TestCriterion.Reverse, Pass.Passed },
                        { TestCriterion.Signals, Pass.Passed },
                    },
                    Result = Pass.Passed,
                    Comments = "trainee drives too fast"
                };

                testsList.Add(test);
            }
            #endregion
        }
    }
}
