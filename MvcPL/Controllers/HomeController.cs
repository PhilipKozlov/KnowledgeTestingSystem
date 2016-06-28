using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for anonymous users.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        #region Actions
        /// <summary>
        /// Displays Index page.
        /// </summary>
        /// <returns> Index View.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays About page.
        /// </summary>
        /// <returns> About View.</returns>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Displays Contact page.
        /// </summary>
        /// <returns> Contact View.</returns>
        public ActionResult Contact()
        {
            return View();
        }
        #endregion
    }
}