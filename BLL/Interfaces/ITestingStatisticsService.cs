using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
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
