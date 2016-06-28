using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Represents test result.
    /// </summary>
    public class DalTestResult : IEntity
    {
        /// <summary>
        /// Gets or sets TestResult identificator.
        /// </summary>
        public int Id { get; set; }
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
        public DalUser User { get; set; }
        /// <summary>
        /// Gets or sets Test.
        /// </summary>
        public DalTest Test { get; set; }
    }
}
