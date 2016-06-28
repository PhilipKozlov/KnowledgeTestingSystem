using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Represents test question.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Gets or sets Question identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Test identificator.
        /// </summary>
        public int TestId { get; set; }
        /// <summary>
        /// Gets or sets Question text.
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets question test.
        /// </summary>
        public virtual Test Test { get; set; }
        /// <summary>
        /// Gets or sets Question answers.
        /// </summary>
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
