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
            int RunningID = 1000;
            int tRunningID = 12345678;


            #region Tester data

            Tester tester;
            for (int i = 0; i < 10; i++)
            {
                tester = new Tester()
                {
                    ID = i,
                    FirstName = $"Tester{i}",
                    LastName = $"ID{RunningID++}",
                    BirthDate = new DateTime(2000, 12, 12),
                    Gender = Gender.Male,
                    Address = new Address()
                    {
                        City = "jerusalem",
                        StreetName = "Jaffa",
                        BuildingNumber = 12,
                    },
                    Experience = 15,
                    MaxWeeklyTests = 1,
                    ExpertiseCar = CarType.Private,
                    WorkSchedule = new bool[5, 6]
                    {
                        { false, false, true, false, false, true },
                        { false, false, false, true, true, false },
                        { true, true, true, false, false, false },
                        { false, false, true, false, false, false },
                        { true, false, false, false, true, false }
                    },
                    MaxDistance = 5
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
                    FirstNameDrivingInstructor = $"Instructor{i - 1050 + 1}",
                    LastNameDrivingInstructor = $"of trainee ID:{i}",
                    LessonsNumber = 28
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
                    TestID = tRunningID,
                    TraineeID = i + 1000,
                    TesterID = i + 1010,
                    Date = new DateTime(2019, 01, i + 1),
                    //Time = new TimeSpan(i, i, 0),
                    StartingPoint = new Address()
                    {
                        City = "Ramat Gat",
                        StreetName = "Aluf David",
                        BuildingNumber = 187
                    },
                    Requirements = new Dictionary<string, Pass>()
                    {
                      { "Distance" , Pass.Failed },
                      { "reverse" , Pass.Failed },
                      { "Mirrors" , Pass.Failed },
                      { "signals" , Pass.Failed }
                    },
                    Success = BE.Pass.Failed,
                    Comment = "trainee drives too fast"
                };

                testsList.Add(test);
            }
            #endregion
        }
    }
}
