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

        bool RemoveTester(int testerID);

        void UpdateTester(Tester tester);

        Tester GetTester(int testerID);

        IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null);

        #endregion

        #region Trainee Functions

        void AddTrainee(Trainee trainee);

        bool RemoveTrainee(int traineeID);

        void UpdateTrainee(Trainee trainee);

        Trainee GetTrainee(int traineeID);

        IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null);

        #endregion

        #region Test Functions

        void AddTest(Test test, int testerID, int traineeID);

        bool RemoveTest(long testID);

        void UpdateTest(Test test);

        Test GetTest(long testID);

        IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null);

        #endregion

        double GapBetweenTwoDates(Test test, int traineeID);
        DateTime SearchForNewDateOfTest(DateTime dateTime);
        bool HasTestAtSameDate(Test test, int testerID, int traineeID);


        double Distance(string address1, string address2);

        IEnumerable<Tester> GetTestersInArea(string adrs);
        int TestsSum(Trainee trainee);
        bool PassedTest(int traineeID);
        IEnumerable<Tester> GetAvailableTesters(DateTime dadateTimete);
        IEnumerable<Test> GetTestsByDay(DateTime dateTime);
        IEnumerable<Test> GetTestsByMonth(DateTime dateTime);





        IEnumerable<IGrouping<CarType, Tester>> TestersExperty(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> TraineesDrivingSchoolList(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> DrivingInstructorList(bool sorted);
        IEnumerable<IGrouping<int, Trainee>> TraineeNumOfTestsList(bool sorted);

    }
}
