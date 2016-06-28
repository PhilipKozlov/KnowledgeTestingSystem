using BLL;
using Logger;
using MvcPL.Models;
using System.Web.Mvc;
using BLL.Interfaces;
using MvcPL.Infrastructure.Mappers;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for role management.
    /// </summary>
    [Authorize]
    public class RoleController : Controller
    {
        #region Fields
        private readonly IRoleService service;
        private readonly ILogger logger = LogManager.GetLogger();
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates RoleController with required parameters.
        /// </summary>
        /// <param name="service"> RoleService instance.</param>
        public RoleController(IRoleService service)
        {
            this.service = service;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays role creation form.
        /// </summary>
        /// <returns> Create view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates new role.
        /// </summary>
        /// <param name="role"> Role to create.</param>
        /// <returns> Redirects to list of users.</returns>
        [HttpPost]
        public ActionResult Create(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.CreateRole(role.ToBllRole());
                }
                catch (RoleAlreadyExistsException ex)
                {
                    logger.Error("Role already exists.", ex);
                    ModelState.AddModelError("", "Role already exists.");
                    return View(role);
                }
                catch
                {
                    return RedirectToAction("Error", "Error");
                }
                return RedirectToAction("Index", "User");
            }
            return View(role);
        }
        #endregion
    }
}