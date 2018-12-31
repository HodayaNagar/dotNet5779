using System;
using System.Collections.Generic;

namespace BE
{
    public class Test
    {
        public long TestID { get; set; }
        public int TraineeID { get; set; }
        public int TesterID { get; set; }
        
        public DateTime TestTime { get; set; }
        //   public TimeSpan Time { get; set; }
        public Address StartingPoint { get; set; }
        public Dictionary<TestCriterion, Pass> Requirements { get; set; }

        public Pass Result { get; set; }
        public String Comments { get; set; }
        public CarType CarType { get; set; }

        public DateTime TestDate { get => TestTime.Date; }

        public Test()
        {
            Requirements = new Dictionary<TestCriterion, Pass>();
                    //{
                    //  { "Distance" , Pass.Failed },
                    //  { "reverse" , Pass.Failed },
                    //  { "Mirrors" , Pass.Failed },
                    //  { "signals" , Pass.Failed }
                    //};
        }


        public override string ToString()
        {
            return $"Test ID: {TestID}{Environment.NewLine}Trainee ID: {TraineeID}{Environment.NewLine}Tester ID: {TesterID}{Environment.NewLine}Test Time: {TestTime.ToString("dd/MM/yyyy HH:mm")}{Environment.NewLine}Starting Point: {StartingPoint}{Environment.NewLine}Result: {Result}{Environment.NewLine}Tester Comments: {Comments}{Environment.NewLine}";
        }
    }
}
