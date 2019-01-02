using BE;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface Idal
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


    }
}
