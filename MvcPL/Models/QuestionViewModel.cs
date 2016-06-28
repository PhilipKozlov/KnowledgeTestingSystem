using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents test question.
    /// </summary>
    public class QuestionViewModel
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
        [Required]
        [Display(Name = "Question text")]
        [MaxLength(200)]
        public string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets Question answers.
        /// </summary>
        [Display(Name = "")]
        public ICollection<AnswerViewModel> Answers { get; set; }

        /// <summary>
        /// Gets or correct answers.
        /// </summary>
        public ICollection<AnswerViewModel> CorrectAnswers => Answers?.Where(a => a.IsCorrect == true).ToList();

        /// <summary>
        /// Gets or sets question number.
        /// </summary>
        public int QuestionNumber { get; set; }
    }
}