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

        public bool RemoveTester(int id)
        {
            Tester t = GetTester(id);
            if (t == null)
            {
                throw new Exception("Tester with the same id not found");
            }
            // צריך להסיר אותו מהמבחנים שהוא רשום אליהם

            // t.RegisteredTestList.Clear();
            testsList.RemoveAll(tl => tl.TesterID == id);
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

        public Tester GetTester(int id)
        {
            return testersList.FirstOrDefault(tl => tl.ID == id);
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

        public bool RemoveTrainee(int id)
        {
            Trainee t = GetTrainee(id);
            if (t == null)
            {
                throw new Exception("Trainee with the same id not found");
            }
            // צריך להסיר אותו מהמבחנים שהוא רשום אליהם
            // t.RegisteredTestList.Clear();
            testsList.RemoveAll(tl => tl.TraineeID == id);
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

        public Trainee GetTrainee(int id)
        {
            return traineesList.FirstOrDefault(tl => tl.ID == id);
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
        public void AddTest(Test test, int idTester, int idTrainee)
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
            test.TesterID = idTester;
            test.TraineeID = idTrainee;
            // t2.RegisteredTestList.Add(test.TestID);
            // t3.RegisteredTestList.Add(test.TestID);
            testsList.Add(test);
        }

        public bool RemoveTest(int id)
        {
            Test t = GetTest(id);
            if (t == null)
                throw new Exception("Test with the same id not found");
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
            //    t2.RegisteredTestList.Remove(id);
            //   t3.RegisteredTestList.Remove(id);
            return testsList.Remove(t);
        }

        public void UpdateTest(Test test)
        {
            int index = testsList.FindIndex(tl => tl.TestID == test.TestID);
            if (index == -1)
            {
                throw new Exception("Test with the same id not found");
            }
            testsList[index] = test;
        }

        public Test GetTest(int id)
        {
            return testsList.FirstOrDefault(tl => tl.TestID == id);
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
