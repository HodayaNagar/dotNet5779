/********************************************************************/
/*
 * Using XML database shows that the developer has no clue what a database supposedly is to do. 
 * A file is not a database by any means, unless there is a lot of support there (in the company...). 
 * In my opinion, XML makes a really crappy database format.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace DAL
{
    public class Dal_XML_imp : IDAL
    {
        private string XmlDbPath = @"C:\Users\HP-PC\source\repos\dotNet5779\Project02_1355_5695_dotNet5779\DbFiles2\";

        private string TestFileName = "Tests.xml";
        private string TesterFileName = "Testers.xml";
        private string TraineeFileName = "Trainees.xml";


        public string TestFile { get => $"{XmlDbPath}{TestFileName}"; }
        public string TesterFile { get => $"{XmlDbPath}{TesterFileName}"; }
        public string TraineeFile { get => $"{XmlDbPath}{TraineeFileName}"; }


        public void AddTest(Test test, int testerID, int traineeID)
        {
            XElement xEle = XElement.Load(TestFile);
            if (xEle != null)
            {
                string testDetails = test.ToXml();
                xEle.Add(testDetails);
                xEle.Save(testDetails);
            }
            else throw new Exception("File not exsist");

        }

        public void AddTester(Tester tester)
        {
            //Tester t = GetTester(tester.ID);
            //if (t != null)
            //{
            //    throw new Exception("Tester with the same id already exists");
            //}

            XElement xEle = XElement.Load(TesterFile);
            if (xEle != null)
            {
                string testerDetails = tester.ToXml();
                xEle.Add(testerDetails);
                xEle.Save(testerDetails);
            }
            else   throw new Exception("File not exsist");

        }

        public void AddTrainee(Trainee trainee)
        {
            XElement xEle = XElement.Load(TraineeFile);
            if (xEle != null)
            {
                string traineeDetails = trainee.ToXml();
                xEle.Add(traineeDetails);
                xEle.Save(traineeDetails);
            }
            else throw new Exception("File not exsist");

        }

        public IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Test GetTest(long testID)
        {
            XElement xEle = XElement.Load(TestFile);
            var stCnt = from address in xEle.Elements("Test")
                            //    where (string)testID.Element("ID") == testID
                        select address;
            throw new NotImplementedException();
        }

        public Tester GetTester(int testerID)
        {
            XElement xEle = XElement.Load(TesterFile);

            throw new NotImplementedException();
        }

        public Trainee GetTrainee(int traineeID)
        {
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