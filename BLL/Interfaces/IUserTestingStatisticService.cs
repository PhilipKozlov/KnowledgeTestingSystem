using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Represents user testing statistics functionality.
    /// </summary>
    public interface IUserTestingStatisticService
    {
        /// <summary>
        /// Gets user testing statistic.
        /// </summary>
        /// <param name="userName"> User name.</param>
        /// <returns> BllUserStatistic instance.</returns>
        BllUserTestingStatistic GetStatisticForUser(string userName);
    }
}
