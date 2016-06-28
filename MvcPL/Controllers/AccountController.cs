using System.Web.Mvc;
using BLL;
using MvcPL.Models;
using System.Web.Security;
using Logger;
using System.Drawing.Imaging;
using BLL.Interfaces;
using MvcPL.Infrastructure.Authentication;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for user account management.
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        #region Fields
        private readonly IUserService service;
        private readonly ILogger logger = LogManager.GetLogger();
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates AccountController with cpecified parameters.
        /// </summary>
        /// <param name="service"> UserService instance.</param>
        public AccountController(IUserService service)
        {
            this.service = service;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays Log in form.
        /// </summary>
        /// <param name="returnUrl"> Return address URL.</param>
        /// <returns> Login view.</returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Posts user log in values.
        /// </summary>
        /// <param name="viewModel"> LogOnViewModel instance.</param>
        /// <param name="returnUrl"> Return address URL.</param>
        /// <returns> View for registered users.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        /// <summary>
        /// Logs off users from the application.
        /// </summary>
        /// <returns> Login view.</returns>
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Fisplays registration form.
        /// </summary>
        /// <returns> Register view.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Posts user registration values.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns> View for registered users.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (viewModel?.Captcha != (string)Session["Captcha"])
            {
                ModelState.AddModelError("Captcha", "Incorrect input.");
                return View(viewModel);
            }

            MembershipUser membershipUser = null;
            if (ModelState.IsValid)
            {
                try
                {
                    membershipUser = ((CustomMembershipProvider)Membership.Provider)
                        .CreateUser(viewModel.Name, viewModel.LastName, viewModel.Email, viewModel.Password);
                }
                catch (UserEmailAlreadyExistsException ex)
                {
                    logger.Error("User with this address already registered.", ex);
                    ModelState.AddModelError("", "User with this address already registered.");
                    return View(viewModel);
                }

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Registration error.");
                }
            }
            return View(viewModel);
        }

        /// <summary>
        /// Sets Captcha image for response.
        /// </summary>
        /// <returns> Null value because captcha image being saved to response output stream.</returns>
        [AllowAnonymous]
        public ActionResult Captcha()
        {
            Session["Captcha"] = CaptchaImage.RandomString(8);
            var ci = new CaptchaImage(Session["Captcha"].ToString(), 200, 50, "Helvetica");
            Response.Clear();
            Response.ContentType = "image/jpeg";
            ci.Image.Save(Response.OutputStream, ImageFormat.Jpeg);
            ci.Dispose();
            return null;
        }

        /// <summary>
        /// Displays login partial form.
        /// </summary>
        /// <returns> Login partial view.</returns>
        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial");
        }
        #endregion
    }
}