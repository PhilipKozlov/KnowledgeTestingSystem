using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Provides functionality for evaluating tests.
    /// </summary>
    public interface ITestEvaluationService
    {
        /// <summary>
        /// Evaluates test completed by user.
        /// </summary>
        /// <param name="completedTest"> Test completed by user.</param>
        /// <returns> TestResult instance.</returns>
        BllTestResult EvaluateTest(BllCompletedTest completedTest);
    }
}
