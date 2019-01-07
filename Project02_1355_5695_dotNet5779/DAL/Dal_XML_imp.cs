/********************************************************************/
/*
 * Using XML database shows that the developer has no clue what a database supposedly is to do. 
 * A file is not a database by any means, unless there is a lot of support there (in the company...). 
 * In my opinion, XML makes a really crappy database format.
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;

namespace DAL
{
    public class Dal_XML_imp : IDAL
    {

        private List<Tester> testersList;
        private List<Trainee> traineesList;
        private List<Test> testsList;

        public List<Tester> Testers
        {
            get
            {
                if (testersList == null)
                    testersList = loadListFromXMLTester(TesterFile);

                return testersList;
            }

            set
            {
                if (testersList != null)
                  saveListToXMLTester(testersList, TesterFile);
            }
        }
        public List<Trainee> Trainees
        {
            get
            {
                if (traineesList == null)
                    traineesList = loadListFromXMLTrainee(TraineeFile);

                return traineesList;
            }
            set
            {
                if (traineesList != null)
                    saveListToXMLTrainee(traineesList, TraineeFile);
            }
        }
        public List<Test> Tests
        {
            get
            {
                if (testsList == null)
                    testsList = loadListFromXMLTest(TestFile);

                return testsList;
            }
            set
            {
                if (testsList != null)
                    saveListToXMLTest(testsList, TestFile);
            }
        }

        //public Dal_XML_imp()
        //{
        //    testersList = loadListFromXMLTester(TesterFile);
        //    traineesList = loadListFromXMLTrainee(TraineeFile);
        //    testsList = loadListFromXMLTest(TestFile);
        //}
        public static List<Tester> loadListFromXMLTester(string path)
        {
            List<Tester> list = new List<Tester>();
            XElement xEle = XElement.Load(path);
            var gg = xEle.Elements().ToArray();
            var tt = gg.Select(x => x.ToString().ToObject<Tester>()).ToList();
            return tt;
        }
        public static List<Trainee> loadListFromXMLTrainee(string path)
        {
            List<Trainee> list = new List<Trainee>();
            XElement xEle = XElement.Load(path);
            var gg = xEle.Elements().ToArray();
            var tt = gg.Select(x => x.ToString().ToObject<Trainee>()).ToList();
            return tt;
        }
        public static List<Test> loadListFromXMLTest(string path)
        {
            List<Test> list = new List<Test>();
            XElement xEle = XElement.Load(path);
            var gg = xEle.Elements().ToArray();
            var tt = gg.Select(x => x.ToString().ToObject<Test>()).ToList();
            return tt;
        }


        public static void saveListToXML(List<Object> list, string path)
        {
            foreach (var item in list)
            {
                string detail = item.ToXml().Remove(0, 40);
                //<?xml version="1.0" encoding="utf-8"?>
                Console.WriteLine(detail);
                XElement xEle = XElement.Load(path);
                xEle.Add(detail);
                xEle.Save(path);
            }
        }

        public static void saveListToXMLTester(List<Tester> list, string path)
        {
            foreach (var item in list)
            {
                string testerDetail = item.ToXml().Remove(0, 40);
                //<?xml version="1.0" encoding="utf-8"?>
                Console.WriteLine(testerDetail);
                XElement xEle = XElement.Load(path);
                xEle.Add(testerDetail);
                xEle.Save(path);
            }
        }
        public static void saveListToXMLTrainee(List<Trainee> list, string path)
        {
            foreach (var item in list)
            {
                string traineeDetail = item.ToXml().Remove(0, 40);
                //<?xml version="1.0" encoding="utf-8"?>
                Console.WriteLine(traineeDetail);
                XElement xEle = XElement.Load(path);
                xEle.Add(traineeDetail);
                xEle.Save(path);
            }
        }
        public static void saveListToXMLTest(List<Test> list, string path)
        {
            foreach (var item in list)
            {
                string testDetail = item.ToXml().Remove(0, 40);
                //<?xml version="1.0" encoding="utf-8"?>
                Console.WriteLine(testDetail);
                XElement xEle = XElement.Load(path);
                xEle.Add(testDetail);
                xEle.Save(path);
            }
        }





        private string XmlDbPath = @"C:\Users\Owner\source\repos\dotNet5779\Project02_1355_5695_dotNet5779\DbFiles2\";
        //private string XmlDbPath = @"C:\Users\HP-PC\source\repos\dotNet5779\Project02_1355_5695_dotNet5779\DbFiles2\";

        private string TestFileName = "Tests.xml";
        private string TesterFileName = "Testers.xml";
        private string TraineeFileName = "Trainees.xml";


        public string TestFile { get => $"{XmlDbPath}{TestFileName}"; }
        public string TesterFile { get => $"{XmlDbPath}{TesterFileName}"; }
        public string TraineeFile { get => $"{XmlDbPath}{TraineeFileName}"; }


        //public void Add(Tester t)
        //{
        //    XElement xEle = XElement.Load(TestFile);
        //    if (xEle != null)
        //    {
        //        string testDetail = test.ToXml();
        //        //<?xml version="1.0" encoding="utf-16"?>
        //        testDetail = testDetail.Remove(0, 40);
        //        Console.WriteLine(testDetail);
        //        xEle.Add(testDetail);
        //        xEle.Save(TestFile);
        //    }
        //    else throw new Exception("File not exsist");

        //}


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

        public bool RemoveTester(int testerID)
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

        public Tester GetTester(int testerID)
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

        public bool RemoveTrainee(int traineeID)
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

        public Trainee GetTrainee(int traineeID)
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

        public void AddTest(Test test, int testerID, int traineeID)
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
