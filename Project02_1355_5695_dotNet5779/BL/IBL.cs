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
        bool RemoveTester(int id);
        void UpdateTester(Tester tester);
        Tester GetTester(int id);
        IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null);
        #endregion

        #region Trainee Functions
        void AddTrainee(Trainee trainee);
        bool RemoveTrainee(int id);
        void UpdateTrainee(Trainee trainee);
        Trainee GetTrainee(int id);
        IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null);
        #endregion

        #region Test Functions
        void AddTest(Test test, int idTester, int idTrainee);
        bool RemoveTest(int id);
        void UpdateTest(Test test);
        Test GetTest(int id);
        IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null);
        #endregion

        int TestsSum(Trainee t);
        bool PassedTest(int idTrainee, int idTest);
        IEnumerable<Tester> GetDistance(int adrs);
        IEnumerable<Tester> GetAvailableTesters(DateTime date);
        IEnumerable<Test> GetTestsByDay();



        IEnumerable<IGrouping<CarType, Tester>> TestersExperty(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> TraineesDrivingSchoolList(bool sorted);
        IEnumerable<IGrouping<string, Trainee>> DrivingInstructorList(bool sorted);
        IEnumerable<IGrouping<int, Trainee>> TraineeNumOfTestsList(bool sorted);

    }
}
