using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Represents TestResult functionality.
    /// </summary>
    public interface ITestResultService
    {
        /// <summary>
        /// Gets as single test result with given id.
        /// </summary>
        /// <param name="id"> TestResult id.</param>
        /// <returns> TestResult with given id.</returns>
        BllTestResult GetTestResult(int id);
        /// <summary>
        /// Gets all test results.
        /// </summary>
        /// <returns> IEnumerable`1 of test results.</returns>
        IEnumerable<BllTestResult> GetAllTestResults();

        /// <summary>
        /// Gets test results for specified test.
        /// </summary>
        /// <param name="test"> Test instance.</param>
        /// <returns> IEnumerable` of test results.</returns>
        IEnumerable<BllTestResult> GetTestResultsByTest(BllTest test);

        /// <summary>
        /// Gets test results for specified user.
        /// </summary>
        /// <param name="userName"> User name.</param>
        /// <returns> IEnumerable` of test results.</returns>
        IEnumerable<BllTestResult> GetTestResultsByUser(string userName);
    }
}
