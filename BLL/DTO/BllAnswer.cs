using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Represents single answer to the question.
    /// </summary>
    public class BllAnswer
    {
        /// <summary>
        /// Gets or sets Answer identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Question identificator.
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// Gets or sets Answer text.
        /// </summary>
        public string AnswerText { get; set; }
        /// <summary>
        /// Gets or sets weather the answer is correct.
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}
