using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Represents test result.
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Gets or sets TestResult identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets User identificator.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets Test identificator.
        /// </summary>
        public int? TestId { get; set; }
        /// <summary>
        /// Gets or sets date and time.
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Gets or sets grade.
        /// </summary>
        public double Grade { get; set; }
        /// <summary>
        /// Gets or sets time spent upon completing the test.
        /// </summary>
        public TimeSpan TimeSpent { get; set; }

        /// <summary>
        /// Gets or sets User.
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets Test.
        /// </summary>
        public virtual Test Test { get; set; }
    }
}
