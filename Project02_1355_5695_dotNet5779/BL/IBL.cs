using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        #region Tester Functions

        void AddTester(Tester tester);

        bool RemoveTester(long testerID);

        void UpdateTester(Tester tester);

        Tester GetTester(long testerID);

        IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null);

        #endregion

        #region Trainee Functions

        void AddTrainee(Trainee trainee);

        bool RemoveTrainee(long traineeID);

        void UpdateTrainee(Trainee trainee);

        Trainee GetTrainee(long traineeID);

        IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null);

        #endregion

        #region Test Functions

        void AddTest(Test test, long testerID, long traineeID);

        bool RemoveTest(long testID);

        void UpdateTest(Test test);

        Test GetTest(long testID);

        IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null);

        #endregion

        double DifferenceBetweenTwoDates(Test test, long traineeID);
        DateTime SearchForNewDateOfTest(DateTime date);
        bool HasTestAtSameDate(Test test, long testerID, long traineeID);


        //int Distance(string address1, string address2);

        IEnumerable<Tester> GetDistance(int adrs);
        int TestsSum(Trainee trainee);
        bool PassedTest(long traineeID);
        IEnumerable<Tester> GetAvailableTesters(DateTime date);
        IEnumerable<Test> GetTestsByDay(DayOfWeek dayOfWeek);






        IEnumerable<IGrouping<CarType, Tester>> TestersExperty(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> TraineesDrivingSchoolList(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> DrivingInstructorList(bool sorted);
        IEnumerable<IGrouping<int, Trainee>> TraineeNumOfTestsList(bool sorted);

    }
}
