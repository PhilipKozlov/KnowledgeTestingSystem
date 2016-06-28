using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Contains general statistics.
    /// </summary>
    public class TestingStatisticViewModel
    {
        /// <summary>
        /// Gets or sets number of tets.
        /// </summary>
        [Display(Name = "Total number of tests")]
        public int TotalNumberOfTests { get; set; }
        /// <summary>
        /// Gets or sets average number of created testsd per day.
        /// </summary>
        [Display(Name = "Tests created / day")]
        public double CreatedTestsPerDay { get; set; }
        /// <summary>
        /// Gets or sets average number of completed testsd per day.
        /// </summary>
        [Display(Name = "Tests completed / day")]
        public double CompletedTestsPerDay { get; set; }
        /// <summary>
        /// Gets or sets total time spent on completing tests.
        /// </summary>
        [Display(Name = "Total time spent")]
        public TimeSpan TotalTestingTime { get; set; }

        /// <summary>
        /// Gets or sets a collection of user statistics.
        /// </summary>
        public ICollection<UserTestingStatisticViewModel> UserStatistics { get; set; }
    }
}