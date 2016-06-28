using System;
using System.Collections.Generic;
using DAL.Interfaces;

namespace DAL.DTO
{
    /// <summary>
    /// Represents test.
    /// </summary>
    public class DalTest : IEntity
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
        public DalUser User { get; set; }
        /// <summary>
        /// Gets or sets test subject.
        /// </summary>
        public DalSubject Subject { get; set; }
        /// <summary>
        /// Gets or sets test questions.
        /// </summary>
        public ICollection<DalQuestion> Questions { get; set; }
    }
}
