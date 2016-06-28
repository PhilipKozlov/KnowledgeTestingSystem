using DAL.DTO;

namespace DAL.Interfaces
{
    /// <summary>
    /// Represents TestResult repository functionality.
    /// </summary>
    public interface ITestResultRepository : IRepository<DalTestResult>
    {
        /// <summary>
        /// Adds new test result to data storage.
        /// </summary>
        /// <param name="testResult"> Test result to add.</param>
        void Create(DalTestResult testResult);
    }
}
