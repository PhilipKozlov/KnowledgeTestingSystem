using BLL;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcPL
{
    /// <summary>
    /// Defines the methods, properties, and events that are common to all MVC applications.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Fields
        private readonly ILogger logger = LogManager.GetLogger();
        #endregion

        #region Protected Methods
        /// <summary>
        /// Represents application main entry point.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Handles all errors in application
        /// </summary>
        /// <param name="sender"> Object that caused the exception.</param>
        /// <param name="e"> Parameters of the exception.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            logger.Error(Server.GetLastError());
        }
        #endregion

    }
}

