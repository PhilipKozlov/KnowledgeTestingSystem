using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MvcPL.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for user and site statistics.
    /// </summary>
    [Authorize]
    public class StatisticsController : Controller
    {
        #region Fields
        private readonly IUserTestingStatisticService userStatisticService;
        private readonly ITestingStatisticsService testingStatisticService;
        #endregion

        #region Cnstructors
        /// <summary>
        /// Instanciates StatisticsController with specified parameters.
        /// </summary>
        /// <param name="userStatisticService"> UserTestingStatisticService instance.</param>
        /// <param name="testingStatisticService"> TestingStatisticsService instance</param>
        public StatisticsController(IUserTestingStatisticService userStatisticService, ITestingStatisticsService testingStatisticService)
        {
            this.userStatisticService = userStatisticService;
            this.testingStatisticService = testingStatisticService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays user statistics.
        /// </summary>
        /// <param name="userName"> User email.</param>
        /// <returns> UserStatistic view.</returns>
        public ActionResult UserStatistic(string userName)
        {
            var userStatistics = userStatisticService.GetStatisticForUser(userName)?.ToUserTestigStatisticViewModel();
            return View(userStatistics);
        }

        /// <summary>
        /// Displays site statistics.
        /// </summary>
        /// <returns> Statistic view.</returns>
        public ActionResult Statistic()
        {
            var statistics = testingStatisticService.GetStatistics()?.ToTestingStatisticViewModel();
            return View(statistics);
        }

        /// <summary>
        /// Displays user statistics.
        /// </summary>
        /// <param name="pageNumber"> Page number.</param>
        /// <returns> UserStatisticPartial view.</returns>
        [ChildActionOnly]
        public ActionResult UserStatistics(int? pageNumber)
        {
            var statistics = testingStatisticService.GetStatistics()?.ToTestingStatisticViewModel();
            return PartialView("_UserStatisticPartial", statistics.UserStatistics.ToPagedList(pageNumber ?? 1, 10));
        }
        #endregion
    }
}