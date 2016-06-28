using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Represents test question.
    /// </summary>
    public class DalQuestion : IEntity
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
        /// Gets or sets Question answers.
        /// </summary>
        public ICollection<DalAnswer> Answers { get; set; }
    }
}
