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

        int TestsSum(Trainee trainee);
        bool PassedTest(long traineeID, long testID);
        IEnumerable<Tester> GetDistance(int adrs);
        IEnumerable<Tester> GetAvailableTesters(DateTime date);
        IEnumerable<Test> GetTestsByDay();



        IEnumerable<IGrouping<CarType, Tester>> TestersExperty(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> TraineesDrivingSchoolList(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> DrivingInstructorList(bool sorted);
        IEnumerable<IGrouping<int, Trainee>> TraineeNumOfTestsList(bool sorted);

    }
}
