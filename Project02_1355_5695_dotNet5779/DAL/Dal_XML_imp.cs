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

        private static List<Tester> testersList;
        private static List<Trainee> traineesList;
        private static List<Test> testsList;

        public Dal_XML_imp()
        {
            testersList = loadListFromXML(TesterFile);
            traineesList = loadListFromXML(TraineeFile);
            testsList = loadListFromXML(TestFile);
        }


        public static void saveListToXML(List<Object> list, string path)
        {
            //XmlSerializer x = new XmlSerializer(list.GetType());
            //FileStream fs = new FileStream(path, FileMode.Create);
            //x.Serialize(fs, list);
        }

        public static dynamic loadListFromXML(string path)
        {
            //XDocument xmlDoc = XDocument.Load(path);
            //var list = xmlDoc.Root.Elements()
            //                           .Select(element => element.Value)
            //                           .ToList();
            //return list;

            List<Object> list = new List<Object>();
            XElement xEle = XElement.Load(path);
            foreach (var item in xEle.Elements())
            {
                list.Add(item);
            }
            return list;
        }


        


        private string XmlDbPath = @"C:\Users\Owner\source\repos\dotNet57792\Project02_1355_5695_dotNet5779\DbFiles2\";
        //private string XmlDbPath = @"C:\Users\HP-PC\source\repos\dotNet5779\Project02_1355_5695_dotNet5779\DbFiles2\";

        private string TestFileName = "Tests.xml";
        private string TesterFileName = "Testers.xml";
        private string TraineeFileName = "Trainees.xml";


        public string TestFile { get => $"{XmlDbPath}{TestFileName}"; }
        public string TesterFile { get => $"{XmlDbPath}{TesterFileName}"; }
        public string TraineeFile { get => $"{XmlDbPath}{TraineeFileName}"; }


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

            XElement xEle = XElement.Load(TestFile);
            if (xEle != null)
            {
                string testDetail = test.ToXml();
                //<?xml version="1.0" encoding="utf-16"?>
                testDetail = testDetail.Remove(0, 40);
                Console.WriteLine(testDetail);
                xEle.Add(testDetail);
                xEle.Save(TestFile);
            }
            else throw new Exception("File not exsist");

        }

        public void AddTester(Tester tester)
        {

            foreach (var item in testersList)
            {
                Console.WriteLine(item);
            }


            Tester t = GetTester(tester.ID);
            if (t != null)
            {
                throw new Exception("Tester with the same id already exists");
            }

            XElement xEle = XElement.Load(TesterFile);
            if (xEle != null)
            {
                string testerDetails = tester.ToXml();
                //<?xml version="1.0" encoding="utf-16"?>
                testerDetails = testerDetails.Remove(0, 40);
                Console.WriteLine(testerDetails);
                xEle.Add(testerDetails);
                xEle.Save(TesterFile);

            }
            else throw new Exception("File not exsist");

        }

        public void AddTrainee(Trainee trainee)
        {
            Trainee t = GetTrainee(trainee.ID);
            if (t != null)
            {
                throw new Exception("Trainee with the same id already exists");
            }

            XElement xEle = XElement.Load(TraineeFile);
            if (xEle != null)
            {
                string traineeDetail = trainee.ToXml();
                //<?xml version="1.0" encoding="utf-16"?>
                traineeDetail = traineeDetail.Remove(0, 40);
                Console.WriteLine(traineeDetail);
                xEle.Add(traineeDetail);
                xEle.Save(TraineeFile);
            }
            else throw new Exception("File not exsist");
        }

        public IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null)
        {
            XElement xEle = XElement.Load(TesterFile);
            if (xEle != null)
            {
                IEnumerable<XElement> getAllTesters = xEle.Elements();
                // return getAllTesters;
                throw new Exception("File not exsist");
            }
            else throw new Exception("File not exsist");
        }

        public IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null)
        {
            XElement xEle = XElement.Load(TestFile);
            if (xEle != null)
            {
                IEnumerable<XElement> getAllTests = xEle.Elements();
                // return getAllTests;
                throw new Exception("File not exsist");
            }
            else throw new Exception("File not exsist");
        }

        public IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null)
        {
            XElement xEle = XElement.Load(TraineeFile);
            if (xEle != null)
            {
                IEnumerable<XElement> getAllTrainees = xEle.Elements();
                // return getAllTrainees;
                throw new Exception("File not exsist");
            }
            else throw new Exception("File not exsist");
        }

        public Test GetTest(long testID)
        {
            XElement xEle = XElement.Load(TestFile);
            var getTest = from address in xEle.Elements("Test")
                          where (string)address.Element("ID") == $"{testID}"
                          select address;
            if (getTest.Count() != 1)
                throw new Exception("Test not exsist");

            // return getTest;
            throw new NotImplementedException();
        }

        public Tester GetTester(int testerID)
        {
            XElement xEle = XElement.Load(TesterFile);
            var getTester = from address in xEle.Elements("Tester")
                            where (string)address.Element("ID") == $"{testerID}"
                            select address;
            if (getTester.Count() != 1)
                throw new Exception("Tester not exsist");

            // return getTester;
            throw new NotImplementedException();
        }

        public Trainee GetTrainee(int traineeID)
        {
            XElement xEle = XElement.Load(TraineeFile);
            var getTrainee = from address in xEle.Elements("Trainee")
                             where (string)address.Element("ID") == $"{traineeID}"
                             select address;
            if (getTrainee.Count() != 1)
                throw new Exception("Trainee not exsist");

            // return getTrainee;
            throw new NotImplementedException();
        }

        public bool RemoveTest(long testID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTester(int testerID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTrainee(int traineeID)
        {
            try
            {
                XElement xEle = XElement.Load(TraineeFile);
                if (xEle != null)
                {
                    var addr = xEle.Elements("Trainee").ToList();
                    foreach (XElement addEle in addr)
                        addEle.SetElementValue("ID", traineeID);
                }
                else throw new Exception("File not exsist");

            }
            catch
            {
                throw new NotImplementedException();
            }
            return true;
        }

        public void UpdateTest(Test test)
        {
            throw new NotImplementedException();
        }

        public void UpdateTester(Tester tester)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }
    }
}