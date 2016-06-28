using System.Linq;
using System.Web.Mvc;
using PagedList;
using BLL.Interfaces;
using MvcPL.Infrastructure.Mappers;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for test subjects.
    /// </summary>
    [Authorize]
    public class SubjectController : Controller
    {
        #region Fields
        private readonly ISubjectService subjectService;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates SubjectController with specified parameters.
        /// </summary>
        /// <param name="subjectService"></param>
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays Index page.
        /// </summary>
        /// <returns> Index View.</returns>
        [ChildActionOnly]
        public ActionResult Index(int? pageNumber)
        {
            var subjects = subjectService.GetAllSubjects().Select(s => s.ToSubjectViewModel());
            return PartialView(subjects.ToPagedList(pageNumber ?? 1, 10));
        }
        #endregion
    }
}