using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Experience { get; set; }
        public CarType ExpertiseCar { get; set; }
        public int MaxWeeklyTests { get; set; }
        public int WeeklyTests { get; set; }
        public int MaxDistance { get; set; }
        public bool[,] WorkSchedule = new bool[5, 6];
        //{
        //            { true, true, true, true, true, true },
        //            { true, true, true, true, true, true },
        //            { true, true, true, true, true, true },
        //            { true, true, true, true, true, true },
        //            { true, true, true, true, true, true }
        //};

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

        public bool isWorking(DateTime date)
        {
            return WorkSchedule[(int)date.DayOfWeek, date.Hour] == true;
        }

        public override string ToString()
        {
            return $"years of experience : {Experience} /n experty of car : {ExpertiseCar} /n max number of test in week : {MaxWeeklyTests} /n max distance of address tester can test : {MaxDistance} /n";
        }
    }
}