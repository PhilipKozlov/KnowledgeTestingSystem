using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents test.
    /// </summary>
    public class TestViewModel
    {
        /// <summary>
        /// Gets or sets Test identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets user identificator.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets Test name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets  time when test was created.
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets weather the test has a time limit.
        /// </summary>
        [Required]
        [Display(Name = "Is timed")]
        public bool IsTimed { get; set; }
        /// <summary>
        /// Gets or sets time limit to complete the test.
        /// </summary>
        [Display(Name = "Time to complete")]
        public TimeSpan TimeToComplete { get; set; }

        /// <summary>
        /// Gets or sets test subject.
        /// </summary>
        [Required]
        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
        /// <summary>
        /// Gets or sets subject identificator.
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets test questions.
        /// </summary>
        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}