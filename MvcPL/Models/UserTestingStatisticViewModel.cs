using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Contains test statistics for each user.
    /// </summary>
    public class UserTestingStatisticViewModel
    {
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [Display(Name = "User")]
        public string UserName {get; set;}
        /// <summary>
        /// Gets or sets total number of completed tests.
        /// </summary>
        [Display(Name = "Completed tests")]
        public int NumberOfCompletedTests { get; set; }
        /// <summary>
        /// Gets or sets average grade.
        /// </summary>
        [Display(Name = "Average grade")]
        public double AverageGrade { get; set; }
        /// <summary>
        /// Gets or sets max grade.
        /// </summary>
        [Display(Name = "Max. grade")]
        public double MaxGrade { get; set; }
        /// <summary>
        /// Gets or sets min grade.
        /// </summary>
        [Display(Name = "Min. grade")]
        public double MinGrade { get; set; }
        /// <summary>
        /// Gets or sets max test time.
        /// </summary>
        [Display(Name = "Max. test time")]
        public TimeSpan MaxTestTime { get; set; }
        /// <summary>
        /// Gets or sets min test time.
        /// </summary>
        [Display(Name = "Min. test time")]
        public TimeSpan MinTestTime { get; set; }
    }
}