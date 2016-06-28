using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Concrete
{
    /// <summary>
    /// Represents testing statistics functionality.
    /// </summary>
    public class TestingStatisticsService : ITestingStatisticsService
    {
        #region Fields
        private readonly ITestResultService service;
        private readonly ITestService testService;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates StatisticService with specified parameters.
        /// </summary>
        /// <param name="service"> ITestResultService instance.</param>
        /// <param name="testService"> ITestResultService instance.</param>
        /// <exception> System.ArgumentNullException if service is null.</exception>
        public TestingStatisticsService(ITestResultService service, ITestService testService)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (testService == null) throw new ArgumentNullException(nameof(testService));
            this.service = service;
            this.testService = testService;
        }
        #endregion

        #region IStatisticsService Methods
        /// <summary>
        /// Gets testing statistic.
        /// </summary>
        /// <returns> BllTestingStatistic instance.</returns>
        public BllTestingStatistic GetStatistics()
        {
            var userStatistics = new List<BllUserTestingStatistic>();
            var testResults = service.GetAllTestResults().ToList();

            return new BllTestingStatistic
            {
                UserStatistics = GetUserStatistics(testResults),
                TotalNumberOfTests = testService.GetAllTests().Count(),
                CreatedTestsPerDay = GetTestsPerDay(testService.GetAllTests(), t=>t.Created),
                CompletedTestsPerDay = GetTestsPerDay(testResults, tr => tr.DateTime),
                TotalTestingTime = GetTotalTestingTime(testResults)
            };
        }
        #endregion

        #region Private Methods
        private IEnumerable<BllUserTestingStatistic> GetUserStatistics(IEnumerable<BllTestResult> testResults)
        {
            var userStatistics = new List<BllUserTestingStatistic>();
            var users = testResults.Select(tr => tr.UserId).Distinct();

            foreach (var user in users)
            {
                var userTestResults = testResults.Where(tr => tr.UserId == user);
                userStatistics.Add(new BllUserTestingStatistic
                {
                    UserName = userTestResults.FirstOrDefault().UserName,
                    NumberOfCompletedTests = userTestResults.Count(),
                    AverageGrade = userTestResults.Average(tr => tr.Grade),
                    MaxGrade = userTestResults.Max(tr => tr.Grade),
                    MinGrade = userTestResults.Min(tr => tr.Grade),
                    MaxTestTime = userTestResults.Max(tr => tr.TimeSpent),
                    MinTestTime = userTestResults.Min(tr => tr.TimeSpent),
                });
            }
            return userStatistics;
        }

        private double GetTestsPerDay<T>(IEnumerable<T> collection, Expression<Func<T, DateTime>> func)
        {
            var count = collection.Count();
            if (count > 0)
            {
                var days = (DateTime.Now - collection.Min(func.Compile())).Days;
                return count > 0 ? (double)count / (days == 0 ? 1 : days) : 0;
            }
            return 0;
        }

        private TimeSpan GetTotalTestingTime(IEnumerable<BllTestResult> testResults) => testResults.Select(tr => tr.TimeSpent).Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
        #endregion
    }
}
