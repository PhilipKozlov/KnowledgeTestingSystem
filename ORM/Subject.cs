using System.Collections.Generic;

namespace ORM
{
    /// <summary>
    /// Represents test subject.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Gets or sets Subject identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Subject name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets all test of Subject.
        /// </summary>
        public virtual ICollection<Test> Tests { get; set; }
    }
}
