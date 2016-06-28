using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents completed test.
    /// </summary>
    public class CompletedTestViewModel
    {
        /// <summary>
        /// Gets or sets Test.
        /// </summary>
        public TestViewModel Test { get; set; }
        /// <summary>
        /// Gets or sets user identificator.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets collections of choosen answers.
        /// </summary>
        public ICollection<AnswerViewModel> ChoosenAnswers { get; set; }
        /// <summary>
        /// Gets or sets time spent upon completing the test.
        /// </summary>
        [Display(Name = "Time spent")]
        public TimeSpan TimeSpent { get; set; }
    }
}