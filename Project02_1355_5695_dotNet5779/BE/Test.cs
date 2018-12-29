using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        public int TestID { get; set; }
        public int TraineeID { get; set; }
        public int TesterID { get; set; }
        public DateTime Date { get; set; }
        //   public TimeSpan Time { get; set; }
        public Address StartingPoint { get; set; }
        public Dictionary<string, Pass> Requirements = new Dictionary<string, Pass>()
                    {
                      { "Distance" , Pass.Failed },
                      { "reverse" , Pass.Failed },
                      { "Mirrors" , Pass.Failed },
                      { "signals" , Pass.Failed }
                    };
        public Pass Success { get; set; }
        public String Comment { get; set; }
        public CarType CarType { get; set; }

        public override string ToString()
        {
            return $"test ID number : {TestID} /n trainee number : {TraineeID} /n tester number : {TesterID} /n date : {Date}  /n starting point address : {StartingPoint} /n success : {Success} /n comment of tester : {Comment} /n";
        }
    }
}
