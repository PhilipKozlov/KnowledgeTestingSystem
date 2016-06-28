using System.Linq;
using System.Web.Mvc;
using MvcPL.Models;
using PagedList;
using BLL.Interfaces;
using MvcPL.Infrastructure.Mappers;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for tests.
    /// </summary>
    [Authorize]
    public class TestController : Controller
    {
        #region Fields
        private readonly ITestService testService;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates TestController with specified parameters.
        /// </summary>
        /// <param name="testService"> TestService instance.</param>
        public TestController(ITestService testService)
        {
            this.testService = testService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays all tests for specified subject.
        /// </summary>
        /// <param name="subject"> SubjectViewModel instance.</param>
        /// <param name="pageNumber"> Page number.</param>
        /// <returns> Index view.</returns>
        public ActionResult Index(SubjectViewModel subject, int? pageNumber)
        {
            var tests = testService.GetTestsBySubject(subject.ToBllSubject()).Select(t => t.ToTestViewModel());
            if (Request.IsAjaxRequest()) return PartialView(tests.ToPagedList(pageNumber ?? 1, 10));
            return View(tests.ToPagedList(pageNumber ?? 1, 10));
        }

        /// <summary>
        /// Displays Find form.
        /// </summary>
        /// <returns> Find view.</returns>
        [ChildActionOnly]
        public ActionResult Find()
        {
            return PartialView("_SearchPartial");
        }

        /// <summary>
        /// Searches for the tests based on given test name.
        /// </summary>
        /// <param name="testName"> Test name.</param>
        /// <returns> Find view.</returns>
        [HttpPost]
        public ActionResult Find(string testName)
        {
            var tests = testService.GetTestsByName(testName).Select(t => t.ToTestViewModel());
            if (Request.IsAjaxRequest())
            {
                return Json(tests, JsonRequestBehavior.AllowGet);
            }
            return View("SearchResults", tests);
        }

        /// <summary>
        /// Displays test form with requested test based on test id.
        /// </summary>
        /// <param name="id"> Test identificator.</param>
        /// <returns> Test view.</returns>
        public ActionResult Test(int id)
        {
            TestViewModel test = null;
            try
            {
                test = testService.GetTest(id)?.ToTestViewModel();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
            if (test == null) return RedirectToAction("NotFound", "Error");
            if (Session["Test"] == null) Session["Test"] = test;
            return View(test);
        }
        #endregion
    }
}