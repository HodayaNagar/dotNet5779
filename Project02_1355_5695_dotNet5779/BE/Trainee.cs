using System;

namespace BE
{
    public class Trainee
    {
        public int ID { get; set; }
        
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public string MobileNumber { get; set; }

        public CarType CarTrained { get; set; }
        public GearType GearType { get; set; }
        public String DrivingSchool { get; set; }
        public int TotalLessonsNumber { get; set; }
        
        public String DrivingInstructorFirstName { get; set; }
        public String DrivingInstructorLastName { get; set; }

        public string FullName { get => $"{FirstName} {LastName}"; }
        public string DrivingInstructorFullName { get => $"{DrivingInstructorFirstName} {DrivingInstructorLastName}"; }

        public override string ToString()
        {
            return $"Trained on Car of Type: {CarTrained}{Environment.NewLine}Gear Type: {GearType}{Environment.NewLine}Driving School: {DrivingSchool}{Environment.NewLine}Total Lessons Number: {TotalLessonsNumber}{Environment.NewLine}Instructor Name: {DrivingInstructorFullName}{Environment.NewLine}";
        }
    }
}
