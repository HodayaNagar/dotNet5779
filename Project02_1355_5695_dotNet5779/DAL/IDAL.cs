using BE;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface Idal
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

    }
}
