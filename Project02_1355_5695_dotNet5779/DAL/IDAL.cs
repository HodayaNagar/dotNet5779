using BE;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IDAL
    {
        #region Tester Functions

        void AddTester(Tester tester);

        bool RemoveTester(string testerID);

        void UpdateTester(Tester tester);

        Tester GetTester(string testerID);

        IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicate = null);

        #endregion

        #region Trainee Functions

        void AddTrainee(Trainee trainee);

        bool RemoveTrainee(string traineeID);

        void UpdateTrainee(Trainee trainee);

        Trainee GetTrainee(string traineeID);

        IEnumerable<Trainee> GetAllTrainees(Func<Trainee, bool> predicate = null);

        #endregion

        #region Test Functions

        void AddTest(Test test, string testerID, string traineeID);

        bool RemoveTest(long testID);

        void UpdateTest(Test test);

        Test GetTest(long testID);

        IEnumerable<Test> GetAllTests(Func<Test, bool> predicate = null);

        #endregion


    }
}
