using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Represents test question.
    /// </summary>
    public class BllQuestion
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
        public ICollection<BllAnswer> Answers { get; set; }

        /// <summary>
        /// Gets or correct answers.
        /// </summary>
        public ICollection<BllAnswer> CorrectAnswers => Answers?.Where(a => a.IsCorrect == true).ToList();
    }
}
