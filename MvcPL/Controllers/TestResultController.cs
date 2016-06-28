using System.Linq;
using System.Web.Mvc;
using MvcPL.Models;
using PagedList;
using BLL.Interfaces;
using MvcPL.Infrastructure.Mappers;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for test results.
    /// </summary>
    [Authorize]
    public class TestResultController : Controller
    {
        #region Fields
        private readonly ITestResultService service;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates TestResultController with specified parameters.
        /// </summary>
        /// <param name="service"> TestResultService instance.</param>
        public TestResultController(ITestResultService service)
        {
            this.service = service;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays test results for specified user.
        /// </summary>
        /// <param name="userName"> User email.</param>
        /// <param name="pageNumber"> Page number.</param>
        /// <returns> TestResult view.</returns>
        public ActionResult TestResult(string userName, int? pageNumber)
        {
            var testResults = service.GetTestResultsByUser(userName).Select(tr => tr.ToTestResultViewModel());
            return View(testResults.ToPagedList(pageNumber ?? 1, 10));
        }

        /// <summary>
        /// Displays test result after completing the test.
        /// </summary>
        /// <param name="testResult"> TestResultViewModel instance.</param>
        /// <returns> TestingResult view.</returns>
        public ActionResult TestingResult(TestResultViewModel testResult)
        {
            return View(testResult);
        }
        #endregion
    }
}