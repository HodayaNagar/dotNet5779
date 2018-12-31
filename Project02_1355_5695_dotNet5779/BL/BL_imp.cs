using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_imp : IBL
    {
        #region Tester Functions

        public void AddTester(Tester tester)
        {
            if (DateTime.Now.Year - tester.BirthDate.Year < Configuration.MinTesterAge)
            {
                throw new Exception($"Tester is under {Configuration.MinTesterAge}");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().AddTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool RemoveTester(long testerID)
        {
            try
            {
                DAL.FactorySingletonDal.getInstance().RemoveTester(testerID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public void UpdateTester(Tester tester)
        {
            try
            {
                DAL.FactorySingletonDal.getInstance().UpdateTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Tester GetTester(long testerID)
        {
            return DAL.FactorySingletonDal.getInstance().GetTester(testerID);
        }

        public IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null)
        {
            return DAL.FactorySingletonDal.getInstance().GetAllTesters(predicate);
        }
        #endregion

        #region Trainee Functions

        public void AddTrainee(Trainee trainee)
        {
            if (DateTime.Now.Year - trainee.BirthDate.Year < Configuration.MinTraineeAge)
            {
                throw new Exception($"Trainee is under {Configuration.MinTraineeAge}");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().AddTrainee(trainee);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool RemoveTrainee(long traineeID)
        {
            try
            {
                DAL.FactorySingletonDal.getInstance().RemoveTrainee(traineeID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public void UpdateTrainee(Trainee trainee)
        {
            try
            {
                DAL.FactorySingletonDal.getInstance().UpdateTrainee(trainee);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Trainee GetTrainee(long traineeID)
        {
            return DAL.FactorySingletonDal.getInstance().GetTrainee(traineeID);
        }

        public IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null)
        {
            return DAL.FactorySingletonDal.getInstance().GetAllTrainees(predicate);
        }
        #endregion

        #region Test Functions

        public void AddTest(Test test, long testerID, long traineeID)
        {
            Trainee trainee = GetTrainee(test.TraineeID);
            if (trainee == null)
            {
                throw new Exception("Trainee does not exsist");
            }

            Tester tester = GetTester(test.TesterID);
            if (tester == null)
            {
                throw new Exception("Tester does not exsist");
            }

            DateTime lastTest = DateTime.Now;
            //בודקים ברשימת הטסטים האים קיים תלמיד עם אותו תז בפעם האחרונה שלו
            foreach (var item in GetAllTests())
            {
                if (item.TraineeID == test.TraineeID)
                {
                    lastTest = item.TestTime;
                }
            }

            // בודקים את הפרש המבחן הקודם אם היה למבחן החדש
            if ((test.TestTime - lastTest).TotalDays < BE.Configuration.MinGapTest)
            {
                throw new Exception($"The gap between tests is less than {Configuration.MinGapTest}, {(test.TestTime - lastTest).TotalDays} days passed since the last test");
            }

            // בודקים אם בוחן עבר את מקסימום המבחנים לשבוע
            if (tester.WeeklyTests >= tester.MaxWeeklyTests)
            {
                throw new Exception("Tester's schedule is full for this week.");
            }

            //לא ניתן לקבוע מבחן לתלמיד שעשה פחות מ20 שיעורים
            if (trainee.TotalLessonsNumber < Configuration.MinLessons)
            {
                throw new Exception($"Trainee did not do { Configuration.MinLessons } lessons, he lackes {Configuration.MinLessons - trainee.TotalLessonsNumber} lessons");
            }


            //לא ניתן לקבוע מבחן על סוג רכב מסוים לתלמיד שכבר עבר בהצלחה מבחן נהיגה על סוג כזה
            if (test.Result == Pass.Passed)
            {
                // בודקים איזה סוג רכב למד התלמיד
                if (trainee.CarTrained == test.CarType)
                {
                    throw new Exception("Trainee has already passed a test on this type of car");
                }
            }

            //יש להתאים בין סוג הרכב שעליו למד התלמיד להתמחות של הבוחן
            if (trainee.CarTrained != tester.CarSpecializtion)
            {
                throw new Exception("Tester does not suitable for this type of car");
            }

            // לא ניתן לקבוע 2 מבחנים לתלמיד או בוחן באותה שעה
            foreach (var item in GetAllTests())
            {
                //if ()
            }







            try
            {
              DAL.FactorySingletonDal.getInstance().AddTest(test,testerID,traineeID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateTest(Test test)
        {
            //לא ניתן לעדכן מבחן כאשר לא קיימים כל השדות שהבוחן צריך למלא

            try
            {
                FactorySingletonDal.getInstance().UpdateTest(test);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool RemoveTest(long testID)
        {
            try
            {
                DAL.FactorySingletonDal.getInstance().RemoveTest(testID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public Test GetTest(long testID)
        {
            return DAL.FactorySingletonDal.getInstance().GetTest(testID);
        }

        public IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null)
        {
            return DAL.FactorySingletonDal.getInstance().GetAllTests(predicate);
        }
        #endregion



        // מספר מבחנים שתלמיד רשום אליהם
        public int TestsSum(Trainee trainee)
        {
            return GetAllTests(gat => gat.TraineeID == trainee.ID).Count();
        }

        // האם תלמיד עבר מבחן טסט בהצלחה
        public bool PassedTest(long traineeID, long testID)
        {
            Trainee t1 = GetTrainee(traineeID);
            Test t2 = GetTest(testID);
            if (t1 != null && t2 != null)
            {
                if (t2.Result == Pass.Passed)
                {
                    return true;
                }
            }
            return false;
        }

        // כל הבוחנים שגרים בסביבת הכתובת המבוקשת
        public IEnumerable<Tester> GetDistance(int adrs)
        {
            //TO DO:
            // 1. בדיקת מה המ
            Random r = new Random();
            adrs = r.Next(1, 10000);
            return GetAllTesters(gat => gat.MaxDistanceInKilometers < adrs);
        }

        // כל הבוחנים שפנויים באותה שעה 
        public IEnumerable<Tester> GetAvailableTesters(DateTime date)
        {
            return GetAllTesters(gat => gat.IsWorking(date) == true);
        }

        // כל המבחנים לפי יום
        public IEnumerable<Test> GetTestsByDay()
        {
            return null;
        }

        // האם תלמיד עמד בדרישות של המבחן
        public bool PassedRequirements(long testID, long traineeID)
        {
            Test t1 = GetTest(testID);
            if (t1.TraineeID == traineeID)

            {
                foreach (var item in t1.Requirements)
                {
                    if (item.Value != Pass.Passed)
                    {
                        return false;
                    }
                }
                return true;
            }
            throw new Exception();
        }


        //Predicate<Test>

        // רשימת בוחנים מכווצת לפי ההתמחות שלהם
        public IEnumerable<IGrouping<CarType, Tester>> TestersExperty(bool sorted = false)
        {
            if (sorted)
            {
                return from Tester t in GetAllTesters()
                       orderby t.FullName
                       group t by t.CarSpecializtion;
            }
            else
            {
                return from Tester t in GetAllTesters()
                       orderby t.ID
                       group t by t.CarSpecializtion;
            }
        }

        // רשימת תלמידים מכווצת לפי בית ספר לנהיגה
        public IEnumerable<IGrouping<string, Trainee>> TraineesDrivingSchoolList(bool sorted = false)
        {
            if (sorted)
            {
                return from Trainee t in GetAllTrainees()
                       orderby t.FullName
                       group t by t.DrivingSchool;
            }
            else
            {
                return from Trainee t in GetAllTrainees()
                       orderby t.ID
                       group t by t.DrivingSchool;
            }
        }

        // רשימת תלמידים מכווצת לפי מורה נהיגה
        public IEnumerable<IGrouping<string, Trainee>> DrivingInstructorList(bool sorted = false)
        {
            if (sorted)
            {
                return from Trainee t in GetAllTrainees()
                       orderby t.FullName
                       group t by t.DrivingInstructorFullName;
            }
            else
            {
                return from Trainee t in GetAllTrainees()
                       orderby t.ID
                       group t by t.DrivingInstructorFullName;
            }
        }

        // רשימת תלמידים מכווצת לפי מספר הטסטים
        public IEnumerable<IGrouping<int, Trainee>> TraineeNumOfTestsList(bool sorted = false)
        {
            if (sorted)
            {
                return from Trainee t in GetAllTrainees()
                       orderby t.FullName
                       group t by TestsSum(t);
            }
            else
            {
                return from Trainee t in GetAllTrainees()
                       orderby t.ID
                       group t by TestsSum(t);
            }



        }
    }
}
