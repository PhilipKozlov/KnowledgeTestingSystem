using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Represents test.
    /// </summary>
    public class BllTest
    {
        /// <summary>
        /// Gets or sets Test identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Test name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets  time when test was created.
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets weather the test has a time limit.
        /// </summary>
        public bool IsTimed { get; set; }
        /// <summary>
        /// Gets or sets time limit to complete the test.
        /// </summary>
        public TimeSpan TimeToComplete { get; set; }

        /// <summary>
        /// Gets or sets user who created the test.
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// Gets or sets test subject.
        /// </summary>
        public BllSubject Subject { get; set; }
        /// <summary>
        /// Gets or sets test questions.
        /// </summary>
        public ICollection<BllQuestion> Questions { get; set; }
    }
}
