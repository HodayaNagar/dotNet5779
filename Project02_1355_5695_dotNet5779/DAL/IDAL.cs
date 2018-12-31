using BE;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface Idal
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

    }
}
