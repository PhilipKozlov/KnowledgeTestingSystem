using System;
using System.Linq;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Concrete
{
    /// <summary>
    /// Represents system statistics functionality.
    /// </summary>
    public class UserTestingStatisticService : IUserTestingStatisticService
    {
        #region Fields
        private readonly ITestResultService service;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates StatisticService with specified parameters.
        /// </summary>
        /// <param name="service"> ITestResultService instance.</param>
        /// <exception> System.ArgumentNullException if service is null.</exception>
        public UserTestingStatisticService(ITestResultService service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            this.service = service;
        }
        #endregion

        #region IStatisticsService Methods
        /// <summary>
        /// Gets user statistic.
        /// </summary>
        /// <param name="userName"> User name.</param>
        /// <returns> BllUserStatistic instance.</returns>
        public BllUserTestingStatistic GetStatisticForUser(string userName)
        {
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            var testResults = service.GetTestResultsByUser(userName);
            return testResults.Count() > 0 ? new BllUserTestingStatistic
            {
                UserName = userName,
                NumberOfCompletedTests = testResults.Count(),
                AverageGrade = testResults.Average(tr => tr.Grade),
                MaxGrade = testResults.Max(tr => tr.Grade),
                MinGrade = testResults.Min(tr => tr.Grade),
                MaxTestTime = testResults.Max(tr => tr.TimeSpent),
                MinTestTime = testResults.Min(tr => tr.TimeSpent),
            } : null;
        }
        #endregion
    }
}
