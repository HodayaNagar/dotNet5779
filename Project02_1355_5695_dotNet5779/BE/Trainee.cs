using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee
    {
        public int ID { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }

        public CarType CarTrained { get; set; }
        public GearType GearType { get; set; }
        public String DrivingSchool { get; set; }
        public int LessonsNumber { get; set; }
        public string FullNameDrivingInstructor { get => $"{FirstNameDrivingInstructor} {LastNameDrivingInstructor}"; }
        public String FirstNameDrivingInstructor { get; set; }
        public String LastNameDrivingInstructor { get; set; }

        // public List<int> RegisteredTestList { get; set; }

        public override string ToString()
        {
            return $"type of car trained : {CarTrained} /n gear type : {GearType} /n driving school : {DrivingSchool} /n lessons number : {LessonsNumber} /n name of instructor : {FullNameDrivingInstructor} /n";
        }
    }
}
