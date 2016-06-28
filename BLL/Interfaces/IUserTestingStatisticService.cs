using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
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
