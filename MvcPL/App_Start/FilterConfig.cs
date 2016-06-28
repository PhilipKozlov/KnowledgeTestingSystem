using System.Web;
using System.Web.Mvc;

namespace MvcPL
{
    /// <summary>
    /// Configures filters for application.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Adds filters to collection.
        /// </summary>
        /// <param name="filters"> GlobalFilterCollection instance.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
