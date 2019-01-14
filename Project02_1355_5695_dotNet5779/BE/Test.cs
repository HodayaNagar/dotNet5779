using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BE
{
    public class Test
    {
        public long TestID { get; set; }
        public string TraineeID { get; set; }
        public string TesterID { get; set; }

        public DateTime TestTime { get; set; }
        public Address StartingPoint { get; set; }
        [XmlIgnore]
        public Dictionary<TestCriterion, Pass> Requirements { get; set; }

        public Pass Result { get; set; }
        public String Comments { get; set; }
        public CarType CarType { get; set; }

        public DateTime TestDate { get => TestTime.Date; }

        public Test()
        {
            Requirements = new Dictionary<TestCriterion, Pass>();

            Requirements.Add(TestCriterion.Distance, Pass.None);
            Requirements.Add(TestCriterion.Mirrors, Pass.None);
            Requirements.Add(TestCriterion.Reverse, Pass.None);
            Requirements.Add(TestCriterion.Signals, Pass.None);

        }


        public override string ToString()
        {
            return $"Test ID: {TestID}{Environment.NewLine}Trainee ID: {TraineeID}{Environment.NewLine}Tester ID: {TesterID}{Environment.NewLine}Test Time: {TestTime.ToString("dd/MM/yyyy HH:mm")}{Environment.NewLine}Starting Point: {StartingPoint}{Environment.NewLine}Result: {Result}{Environment.NewLine}Tester Comments: {Comments}{Environment.NewLine}";
        }
    }
}
