using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents test result.
    /// </summary>
    public class TestResultViewModel
    {
        /// <summary>
        /// Gets or sets TestResult identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets date and time.
        /// </summary>
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Gets or sets grade.
        /// </summary>
        public double Grade { get; set; }
        /// <summary>
        /// Gets or sets time spent upon completing the test.
        /// </summary>
        [Display(Name = "Time spent")]
        public TimeSpan TimeSpent { get; set; }

        /// <summary>
        /// Gets or sets test identificator.
        /// </summary>
        public int? TestId { get; set; }
        /// <summary>
        /// Gets or sets user identificator.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets test name.
        /// </summary>
        [Display(Name = "Test")]
        public string TestName { get; set; }

    }
}