using System;
using System.Xml.Serialization;
 
namespace BE
{
    public class Tester
    {
        public int ID { get; set; }

        [XmlIgnore]
        public string FullName { get => $"{FirstName} {LastName}"; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public string MobileNumber { get; set; }

        public int Seniority { get; set; } // ותק בעבודה
        public CarType CarSpecializtion { get; set; }
        public int MaxWeeklyTests { get; set; }
        public int WeeklyTests { get; set; }
        public int MaxDistanceInKilometers { get; set; }
        private string workingScheduleStr;
        public string WorkingScheduleStr
        {
            get
               {
                workingScheduleStr = "";
                for (int i = 0; i < Configuration.WorkingDaysInWeek; i++)
                {
                    for (int j = 0; j < Configuration.WorkingHoursInDay; j++)
                    {
                        workingScheduleStr += (WorkingSchedule[i, j] == true) ? $"1" : $"0";
                    }
                    workingScheduleStr += $",";
                }
                return workingScheduleStr;
            }
            set
            {
                int k = 0;
                for (int i = 0; i < Configuration.WorkingDaysInWeek; i++)
                    for (int j = 0; j < Configuration.WorkingHoursInDay; j++)
                    {
                        if (workingScheduleStr[k++] == '1')
                            WorkingSchedule[i, j] = true;
                        if (workingScheduleStr[k++] == '0')
                            WorkingSchedule[i, j] = false;
                    }
            }
        }
        [XmlIgnore]
        public bool[,] WorkingSchedule { get; set; }

        [XmlIgnore]
        public bool[,] AvailableSchedule { get; set; }


        public Tester()
        {
            WorkingSchedule = new bool[Configuration.WorkingDaysInWeek, Configuration.WorkingHoursInDay];

            for (int i = 0; i < Configuration.WorkingDaysInWeek; i++)
                for (int j = 0; j < Configuration.WorkingHoursInDay; j++)
                    WorkingSchedule[i, j] = true;

            AvailableSchedule = new bool[Configuration.WorkingDaysInWeek, Configuration.WorkingHoursInDay];

            for (int i = 0; i < Configuration.WorkingDaysInWeek; i++)
                for (int j = 0; j < Configuration.WorkingHoursInDay; j++)
                    AvailableSchedule[i, j] = true;
        }

        public bool IsWorking(DateTime date)
        {
            return WorkingSchedule[(int)date.DayOfWeek, date.Hour] == true;
        }

        public bool IsAvailable(DateTime date)
        {
            return AvailableSchedule[(int)date.DayOfWeek, date.Hour] == true;
        }

        public override string ToString()
        {
            return $"Seniority: {Seniority}{Environment.NewLine}Car Specializtion: {CarSpecializtion}{Environment.NewLine}Max Number of Tests in Week: {MaxWeeklyTests}{Environment.NewLine}Max Distance from Trainee Address: {MaxDistanceInKilometers}(km){Environment.NewLine}";
        }
    }
}