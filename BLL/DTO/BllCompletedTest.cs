using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    /// <summary>
    /// Represents test that has been completed by user.
    /// </summary>
    public class BllCompletedTest
    {
        /// <summary>
        /// Gets or sets Test.
        /// </summary>
        public BllTest Test { get; set; }
        /// <summary>
        /// Gets or sets user who completed the test.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets collections of choosen answers.
        /// </summary>
        public ICollection<BllAnswer> ChoosenAnswers { get; set; }
        /// <summary>
        /// Gets or sets time spent upon completing the test.
        /// </summary>
        public TimeSpan TimeSpent { get; set; }
    }
}
