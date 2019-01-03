using BE;
using DAL;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_imp : IBL
    {
        static DAL.IDAL dal = DAL.FactorySingletonDal.getInstance();
        #region Tester Functions

        public void AddTester(Tester tester)
        {
            if (IsValidId(tester.ID) == false)
            {
                throw new Exception($"Tester ID is valid");
            }
            if (DateTime.Now.Year - tester.BirthDate.Year < Configuration.MinTesterAge)
            {
                throw new Exception($"Tester is under {Configuration.MinTesterAge}");
            }
            if (DateTime.Now.Year - tester.BirthDate.Year > Configuration.MaxTesterAge)
            {
                throw new Exception($"Tester is over {Configuration.MaxTesterAge}, it's pension age");
            }
            
            try
            {
                dal.AddTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool RemoveTester(int testerID)
        {
            if (IsValidId(testerID) == false)
            {
                throw new Exception($"Tester ID is valid");
            }
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
            if (IsValidId(tester.ID) == false)
            {
                throw new Exception($"Tester ID is valid");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().UpdateTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Tester GetTester(int testerID)
        {
            if (IsValidId(testerID) == false)
            {
                throw new Exception($"Tester ID is valid");
            }
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
            if (IsValidId(trainee.ID) == false)
            {
                throw new Exception($"Trainee ID is valid");
            }
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

        public bool RemoveTrainee(int traineeID)
        {
            if (IsValidId(traineeID) == false)
            {
                throw new Exception($"Trainee ID is valid");
            }
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
            if (IsValidId(trainee.ID) == false)
            {
                throw new Exception($"Trainee ID is valid");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().UpdateTrainee(trainee);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Trainee GetTrainee(int traineeID)
        {
            if (IsValidId(traineeID) == false)
            {
                throw new Exception($"Trainee ID is valid");
            }
            return DAL.FactorySingletonDal.getInstance().GetTrainee(traineeID);
        }

        public IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null)
        {
            return DAL.FactorySingletonDal.getInstance().GetAllTrainees(predicate);
        }
        #endregion

        #region Test Functions

        public void AddTest(Test test, int testerID, int traineeID)
        {
            if (IsValidId(testerID) == false)
            {
                throw new Exception($"Tester ID is valid");
            }
            if (IsValidId(traineeID) == false)
            {
                throw new Exception($"Trainee ID is valid");
            }
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

            // בודקים את הפרש המבחן הקודם אם היה למבחן החדש
            if (DifferenceBetweenTwoDates(test, traineeID) < BE.Configuration.MinGapTest)
            {
                throw new Exception($"The gap between tests is less than {Configuration.MinGapTest}, {DifferenceBetweenTwoDates(test, traineeID)} days passed since the last test");
            }

            //לא ניתן לקבוע מבחן לתלמיד שעשה פחות מ20 שיעורים
            if (trainee.TotalLessonsNumber < Configuration.MinLessons)
            {
                throw new Exception($"Trainee did not do { Configuration.MinLessons } lessons, he needs to do {Configuration.MinLessons - trainee.TotalLessonsNumber} lessons");
            }

            // לא ניתן לקבוע מבחן אם אין בוחן פנוי ןאם אין מציעים תאריך אחר למבחן
            if (GetAvailableTesters(test.TestDate).Count() == 0)
            {
                SearchForNewDateOfTest(test.TestDate);
            }

            // בודקים אם בוחן עבר את מקסימום המבחנים לשבוע
            if (tester.WeeklyTests >= tester.MaxWeeklyTests)
            {
                throw new Exception("Tester's schedule is full for this week");
            }

            // לא ניתן לקבוע 2 מבחנים לתלמיד או בוחן באותה שעה
            if (HasTestAtSameDate(test, testerID, traineeID) == true)
            {
                throw new Exception("Can not set two tests at the same time");
            }

            //לא ניתן לקבוע מבחן על סוג רכב מסוים לתלמיד שכבר עבר בהצלחה מבחן נהיגה על סוג כזה
            if (PassedTest(traineeID) == true)
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

            try
            {
                DAL.FactorySingletonDal.getInstance().AddTest(test, testerID, traineeID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateTest(Test test)
        {
            //לא ניתן לעדכן מבחן כאשר לא קיימים כל השדות שהבוחן צריך למלא
            foreach (var item in test.Requirements)
            {
                if (item.Value == Pass.None)
                {
                    throw new Exception("Tester needs to fill all fields required");
                }
            }

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


        ////////////////////////////////////////////////////////////////////////////////////////////////////////


        public double DifferenceBetweenTwoDates(Test test, int traineeID)
        {
            DateTime lastTest = DateTime.Now;
            //בודקים ברשימת הטסטים האים קיים תלמיד עם אותו תז בפעם האחרונה שלו
            foreach (var item in GetAllTests())
            {
                if (item.TraineeID == traineeID)
                {
                    lastTest = item.TestTime;
                }
            }
            return (test.TestTime - lastTest).TotalDays;
        }

        public DateTime SearchForNewDateOfTest(DateTime date)
        {
            DateTime closestDate = DateTime.Now;
            foreach (var item in GetAllTests())
            {
                if (item.TestDate > date && item.TestDate < closestDate && GetAvailableTesters(item.TestDate).Count() > 0)
                {
                    closestDate = item.TestDate;
                }
            }
            return closestDate;
        }

        public bool HasTestAtSameDate(Test test, int testerID, int traineeID)
        {
            foreach (var item in GetAllTests())
            {
                if (item.TestDate == test.TestDate)
                {
                    if (item.TesterID == testerID || item.TraineeID == traineeID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsValidId(int id)
        {
            if (id < 1 || id > 999999999) return false;
            string fullId = $"{id:000000000}";

            int mone = 0;
            int incNum;
            for (int i = 0; i < 9; i++)
            {
                incNum = Convert.ToInt32(fullId[i].ToString());
                incNum *= (i % 2) + 1;
                if (incNum > 9)
                    incNum -= 9;
                mone += incNum;
            }
            if (mone % 10 == 0)
                return true;
            else
                return false;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////



        private MapPoint GetAddressGeoLocation(string address)
        {
            GoogleLocationService locationService = new GoogleLocationService();
            return locationService.GetLatLongFromAddress(address);
        }

        // מחזירה מרחק בקילומטרים בין 2 נקודות
        private double GetDistanceBetween2Points(MapPoint point1, MapPoint point2)
        {
            double latitudeDistance = (point2.Latitude - point1.Latitude).ToRadians();
            double longtitudeDistance = (point2.Longitude - point1.Longitude).ToRadians();

            double lat1 = point1.Latitude.ToRadians();
            double lat2 = point2.Latitude.ToRadians();

            double a = Math.Sin(latitudeDistance / 2) * Math.Sin(latitudeDistance / 2)
                + Math.Sin(longtitudeDistance / 2) * Math.Sin(longtitudeDistance / 2)
                    * Math.Cos(lat1) * Math.Cos(lat2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return Configuration.EarthRadius * c;
        }


        public double Distance(string address1, string address2)
        {
            //if (string.IsNullOrEmpty())

            //1. מציאת המיקום בכדור הארץ (קו אורך, קו רוחב) של כל כתובת
            MapPoint addrs1Point = GetAddressGeoLocation(address: address1);
            MapPoint addrs2Point = GetAddressGeoLocation(address: address2);

            //2. מציאת המרחק בין 2 הנקודות באמצעות חישוב מתמטי
            return GetDistanceBetween2Points(point1: addrs1Point, point2: addrs2Point);
        }

        // כל הבוחנים שגרים בסביבת הכתובת המבוקשת
        public IEnumerable<Tester> GetDistance(string adrs)
        {
            return GetAllTesters(gat => Distance(gat.Address.ToString(), adrs) < gat.MaxDistanceInKilometers);
        }

        // מספר מבחנים שתלמיד רשום אליהם
        public int TestsSum(Trainee trainee)
        {
            return GetAllTests(gat => gat.TraineeID == trainee.ID).Count();
        }

        // האם תלמיד עמד בדרישות של המבחן
        public bool PassedTest(int traineeID)
        {
            Test t1 = GetAllTests(gat => gat.TraineeID == traineeID).FirstOrDefault();
            t1.Result = Pass.Passed;
            foreach (var item in t1.Requirements)
            {
                if (item.Value != Pass.Passed)
                {
                    t1.Result = Pass.Failed;
                }
            }
            return t1.Result == Pass.Passed;
        }

        // כל הבוחנים שפנויים באותה שעה 
        public IEnumerable<Tester> GetAvailableTesters(DateTime date)
        {
            return GetAllTesters(gat => gat.IsWorking(date) == true && gat.IsAvailable(date) == true);
        }

        // כל המבחנים לפי יום
        public IEnumerable<Test> GetTestsByDay(DayOfWeek dayOfWeek)
        {
            return GetAllTests(gat => gat.TestDate.DayOfWeek == dayOfWeek);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////


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
