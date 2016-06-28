using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents single answer to the question.
    /// </summary>
    public class AnswerViewModel
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
        [Required]
        [Display(Name = "Answer text")]
        [MaxLength(200)]
        public string AnswerText { get; set; }
        /// <summary>
        /// Gets or sets weather the answer is correct.
        /// </summary>
        [Required]
        [Display(Name = "Is correct")]
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Gets or sets weather the answer was selected.
        /// </summary>
        public bool IsSelected { get; set; }
    }
}