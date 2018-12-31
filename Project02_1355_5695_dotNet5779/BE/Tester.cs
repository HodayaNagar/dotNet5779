using System;

namespace BE
{
    public class Tester
    {
        public int ID { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public string MobileNumber { get; set; }

        //public int Experience { get; set; }
        public int Seniority { get; set; } // ותק בעבודה
        //public CarType ExpertiseCar { get; set; }
        public CarType CarSpecializtion { get; set; }
        public int MaxWeeklyTests { get; set; }
        public int WeeklyTests { get; set; }
        public int MaxDistanceInKilometers { get; set; }

        public bool[,] WorkingSchedule { get; set; }


        // public List<int> RegisteredTestList { get; set; }

        //public bool[,] IsAvailable
        //{
        //    get { return IsAvailable; }
        //    set
        //    {
        //        for (int i = 0; i < 6; i++)
        //        {
        //            for (int j = 0; j < 5; j++)
        //            {
        //                IsAvailable[i, j] = value[i, j];
        //            }
        //        }
        //    }
        //}

        public Tester()
        {
            WorkingSchedule = new bool[Configuration.WorkingDaysInWeek, Configuration.WorkingHoursInDay];

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 5; j++)
                    WorkingSchedule[i, j] = true;
        }

        public bool IsWorking(DateTime date)
        {
            return WorkingSchedule[(int)date.DayOfWeek, date.Hour] == true;
        }

        public override string ToString()
        {
            return $"Seniority: {Seniority}{Environment.NewLine}Car Specializtion: {CarSpecializtion}{Environment.NewLine}Max Number of Tests in Week: {MaxWeeklyTests}{Environment.NewLine}Max Distance from Trainee Address: {MaxDistanceInKilometers}(km){Environment.NewLine}";
        }
    }
}