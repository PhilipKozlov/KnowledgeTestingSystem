using BLL;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for user management.
    /// </summary>
    [Authorize]
    public class UserController : Controller
    {
        #region Fields
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates UserController with specified parameters.
        /// </summary>
        /// <param name="userService"> UserService instance.</param>
        /// <param name="roleService"> RoleService instance.</param>
        public UserController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays user information for given user name.
        /// </summary>
        /// <param name="userName"> User email.</param>
        /// <returns> Details view.</returns>
        public ActionResult UserDetails(string userName)
        {
            var user = userService.GetUserByEmail(userName)?.ToUserViewModel();
            if (user == null) return RedirectToAction("NotFound", "Error");
            return View("Details", user);
        }

        /// <summary>
        /// Displays list of users.
        /// </summary>
        /// <param name="pageNumber"> Page number.</param>
        /// <returns> Index view.</returns>
        public ActionResult Index(int? pageNumber)
        {
            var users = userService.GetAllUsers().Select(u => u.ToUserViewModel());
            return View(users.ToPagedList(pageNumber ?? 1, 10));
        }

        /// <summary>
        /// Displays user information for given user id.
        /// </summary>
        /// <param name="id"> User identificator.</param>
        /// <returns> Details view.</returns>
        public ActionResult Details(int id)
        {
            UserViewModel user = null;
            try
            {
                user = userService.GetUser(id)?.ToUserViewModel();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
            if (user == null) RedirectToAction("Error", "Error");
            return View(user);
        }

        /// <summary>
        /// Displays user editor.
        /// </summary>
        /// <param name="id"> User identificator.</param>
        /// <returns> Edit view.</returns>
        public ActionResult Edit(int id)
        {
            var roles = roleService.GetAllRoles().Select(r => r.ToRoleViewModel());
            UserViewModel user = null;
            try
            {
                user = userService.GetUser(id)?.ToUserViewModel();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
            if (user == null) return RedirectToAction("Error", "Error");
            foreach (var role in user.Roles) role.IsSelected = true;
            foreach (var role in roles) if (user.Roles.Where(r => r.Id == role.Id).SingleOrDefault() == null) user.Roles.Add(role);
            return View(user);
        }

        /// <summary>
        /// Post user values.
        /// </summary>
        /// <param name="user"> UserViewModel instance.</param>
        /// <returns> Redirects to list of users.</returns>
        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var temp = user.Roles.ToList();
                temp.RemoveAll(r => r.IsSelected == false);
                user.Roles = temp;
                try
                {
                    userService.UpdateUser(user.ToBllUser());
                }
                catch
                {
                    return RedirectToAction("Error", "Error");
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// Displays user delete form.
        /// </summary>
        /// <param name="id"> User identificator.</param>
        /// <returns> Delete view.</returns>
        public ActionResult Delete(int id)
        {
            UserViewModel user = null;
            try
            {
                user = userService.GetUser(id)?.ToUserViewModel();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
            if (user == null) RedirectToAction("Error", "Error");
            return View(user);
        }

        /// <summary>
        /// Deletes user.
        /// </summary>
        /// <param name="user"> UserViewModel instance.</param>
        /// <returns> Redirects to user list.</returns>
        [HttpPost]
        public ActionResult Delete(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userService.DeleteUser(user.ToBllUser());
                }
                catch
                {
                    return RedirectToAction("Error", "Error");
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }
        #endregion
    }
}
