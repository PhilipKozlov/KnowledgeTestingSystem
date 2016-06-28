using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Represents testing statistics functionality.
    /// </summary>
    public interface ITestingStatisticsService
    {
        /// <summary>
        /// Gets testing statistics.
        /// </summary>
        /// <returns> BllTestingStatistic instance.</returns>
        BllTestingStatistic GetStatistics();
    }
}
