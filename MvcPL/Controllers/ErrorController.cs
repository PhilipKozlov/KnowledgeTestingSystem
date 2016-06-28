using System.Web.Mvc;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for error handling.
    /// </summary>
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        #region Actions
        /// <summary>
        /// Displays NotFound error page.
        /// </summary>
        /// <returns> NotFoun View.</returns>
        public ActionResult NotFound()
        {
            return View();
        }

        /// <summary>
        /// Displays Error page.
        /// </summary>
        /// <returns> Erro view.</returns>
        public ActionResult Error()
        {
            return View();
        }
        #endregion
    }
}