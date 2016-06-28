using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    /// <summary>
    /// Contains general statistics.
    /// </summary>
    public class BllTestingStatistic
    {
        /// <summary>
        /// Gets or sets number of tests.
        /// </summary>
        public int TotalNumberOfTests { get; set; }
        /// <summary>
        /// Gets or sets a collection of user statistics.
        /// </summary>
        public IEnumerable<BllUserTestingStatistic> UserStatistics { get; set; }
        /// <summary>
        /// Gets or sets average number of created testsd per day.
        /// </summary>
        public double CreatedTestsPerDay { get; set; }
        /// <summary>
        /// Gets or sets average number of completed testsd per day.
        /// </summary>
        public double CompletedTestsPerDay { get; set; }
        /// <summary>
        /// Gets or sets total time spent on completing tests.
        /// </summary>
        public TimeSpan TotalTestingTime { get; set; }
    }
}
