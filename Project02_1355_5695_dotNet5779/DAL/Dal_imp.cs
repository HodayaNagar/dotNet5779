using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class Dal_imp : Idal
    {
        private static List<Tester> testersList;
        private static List<Trainee> traineesList;
        private static List<Test> testsList;

        public Dal_imp()
        {
            testersList = new List<Tester>();
            traineesList = new List<Trainee>();
            testsList = new List<Test>();
        }


        #region Tester Functions
        public void AddTester(Tester tester)
        {
            Tester t = GetTester(tester.ID);
            if (t != null)
            {
                throw new Exception("Tester with the same id already exists");
            }
            testersList.Add(tester);
        }

        public bool RemoveTester(long testerID)
        {
            Tester t = GetTester(testerID);
            if (t == null)
            {
                throw new Exception("Tester with the same id not found");
            }
            // צריך להסיר אותו מהמבחנים שהוא רשום אליהם
            testsList.RemoveAll(tl => tl.TesterID == testerID);
            return testersList.Remove(t);
        }

        public void UpdateTester(Tester tester)
        {
            int index = testersList.FindIndex(tl => tl.ID == tester.ID);
            if (index == -1)
            {
                throw new Exception("Tester with the same id not found");
            }
            testersList[index] = tester;
        }

        public Tester GetTester(long testerID)
        {
            return testersList.FirstOrDefault(tl => tl.ID == testerID);
        }

        public IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null)
        {
            if (predicate == null)
            {
                return testersList.AsEnumerable();
            }
            return testersList.Where(predicate);
        }
        #endregion

        #region Trainee Functions
        public void AddTrainee(Trainee trainee)
        {
            Trainee t = GetTrainee(trainee.ID);
            if (t != null)
            {
                throw new Exception("Trainee with the same id already exists");
            }
            traineesList.Add(trainee);
        }

        public bool RemoveTrainee(long traineeID)
        {
            Trainee t = GetTrainee(traineeID);
            if (t == null)
            {
                throw new Exception("Trainee with the same id not found");
            }
            // צריך להסיר אותו מהמבחנים שהוא רשום אליהם
            testsList.RemoveAll(tl => tl.TraineeID == traineeID);
            return traineesList.Remove(t);
        }

        public void UpdateTrainee(Trainee trainee)
        {
            int index = traineesList.FindIndex(tl => tl.ID == trainee.ID);
            if (index == -1)
            {
                throw new Exception("Trainee with the same id not found");
            }
            traineesList[index] = trainee;
        }

        public Trainee GetTrainee(long traineeID)
        {
            return traineesList.FirstOrDefault(tl => tl.ID == traineeID);
        }

        public IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null)
        {
            if (predicate == null)
            {
                return traineesList.AsEnumerable();
            }
            return traineesList.Where(predicate);
        }

        #endregion

        #region Test Functions

        public void AddTest(Test test, long testerID, long traineeID)
        {
            // צריך לבדוק שבוחן ונבחן שרשומים קיימים ברשימות ושהמבחן לא קיים ברשימה
            Test t1 = GetTest(test.TestID);
            if (t1 != null)
            {
                throw new Exception("Test with the same id already exists");
            }
            Tester t2 = GetTester(test.TesterID);
            if (t2 == null)
            {
                throw new Exception("Tester with the same id not found");
            }
            Trainee t3 = GetTrainee(test.TraineeID);
            if (t3 == null)
            {
                throw new Exception("Trainee with the same id not found");
            }
            test.TestID = Configuration.RunningTestID++;
            test.TesterID = testerID;
            test.TraineeID = traineeID;
            t2.AvailableSchedule[(int)test.TestDate.DayOfWeek, test.TestDate.Hour] = false;

            testsList.Add(test);
        }

        public bool RemoveTest(long testID)
        {
            Test t = GetTest(testID);
            if (t == null)
                throw new Exception("Test was not found");
            // צריך לבדוק אם יש בוחן או נבחן שרשומים למבחן
            Tester t2 = GetTester(t.TesterID);
            if (t2 != null)
            {
                throw new Exception("Tester with the same is registered to this test");
            }
            Trainee t3 = GetTrainee(t.TraineeID);
            if (t3 != null)
            {
                throw new Exception("Trainee with the same id is registered to this test");
            }

            return testsList.Remove(t);
        }

        public void UpdateTest(Test test)
        {
            int index = testsList.FindIndex(tl => tl.TestID == test.TestID);
            if (index == -1)
                throw new Exception("Test doesn't exist");

            testsList[index] = test;
        }

        public Test GetTest(long testID)
        {
            return testsList.FirstOrDefault(tl => tl.TestID == testID);
        }

        public IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null)
        {
            if (predicate == null)
            {
                return testsList.AsEnumerable();
            }
            return testsList.Where(predicate);
        }

        #endregion
    }
}
