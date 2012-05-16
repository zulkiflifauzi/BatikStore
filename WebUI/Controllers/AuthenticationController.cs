using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Repository;
using Domain.Interfaces;
using Ninject;
using WebUI.Helper;
using System.Web.Security;

namespace WebUI.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IUserService _userService;

        [Inject]
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewModelLogin model)
        {
            var user = _userService.GetUserByEmail(model.Email);

            if (user != null && PasswordHelper.CreatePasswordHash(model.Password, user.Salt) == user.Password)
            {
                var ticket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, "Administrator");
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Catalogue");
            }
            return Json(null);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication");
        }
    }
}
