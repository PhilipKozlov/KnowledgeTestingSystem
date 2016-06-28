using System;

namespace BLL.DTO
{
    /// <summary>
    /// Contains test statistics for each user.
    /// </summary>
    public class BllUserTestingStatistic
    {
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets total number of completed tests.
        /// </summary>
        public int NumberOfCompletedTests { get; set; }
        /// <summary>
        /// Gets or sets average grade.
        /// </summary>
        public double AverageGrade { get; set; }
        /// <summary>
        /// Gets or sets max grade.
        /// </summary>
        public double MaxGrade { get; set; }
        /// <summary>
        /// Gets or sets min grade.
        /// </summary>
        public double MinGrade { get; set; }
        /// <summary>
        /// Gets or sets max test time.
        /// </summary>
        public TimeSpan MaxTestTime { get; set; }
        /// <summary>
        /// Gets or sets min test time.
        /// </summary>
        public TimeSpan MinTestTime { get; set; }
    }
}
