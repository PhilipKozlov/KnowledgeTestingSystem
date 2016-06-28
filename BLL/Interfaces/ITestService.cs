using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Represents Test functionality.
    /// </summary>
    public interface ITestService
    {
        /// <summary>
        /// Gets as single test with given id.
        /// </summary>
        /// <param name="id"> Test id.</param>
        /// <returns> Test with given id.</returns>
        BllTest GetTest(int id);
        /// <summary>
        /// Gets all tests.
        /// </summary>
        /// <returns> IEnumerable`1 of tests.</returns>
        IEnumerable<BllTest> GetAllTests();
        /// <summary>
        /// Adds new test to data storage.
        /// </summary>
        /// <param name="test"> Test to add.</param>
        void CreateTest(BllTest test);
        /// <summary>
        /// Removes test from data storage.
        /// </summary>
        /// <param name="test"> Test to remove.</param>
        void DeleteTest(BllTest test);
        /// <summary>
        /// Updates test in data storage.
        /// </summary>
        /// <param name="test"> Test to update.</param>
        void UpdateTest(BllTest test);

        /// <summary>
        /// Gets tests for specified subject.
        /// </summary>
        /// <param name="subject"> Subject instance.</param>
        /// <returns> Tests created by specified subject.</returns>
        IEnumerable<BllTest> GetTestsBySubject(BllSubject subject);

        /// <summary>
        /// Gets tests for specified user.
        /// </summary>
        /// <param name="user"> User instance.</param>
        /// <returns> Tests created by specified user.</returns>
        IEnumerable<BllTest> GetTestsByUser(BllUser user);

        /// <summary>
        /// Gets tests that hae specified name.
        /// </summary>
        /// <param name="name"> Test name.</param>
        /// <returns> Tests with specified name.</returns>
        IEnumerable<BllTest> GetTestsByName(string name);
    }
}
