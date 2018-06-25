using TMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null)
                returnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);

            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnUrl = returnUrl;
            }

            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Validate(LoginModel account, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            string decodedUrl = string.Empty;
            if (!string.IsNullOrEmpty(returnUrl)) decodedUrl = Server.UrlDecode(returnUrl);

            if (ModelState.IsValid)
            {
                if (Authentication.LogIn(account.Login, account.Password, account.RememberMe))
                {
                    //return RedirectToAction("Index", "Home");
                    if (Url.IsLocalUrl(decodedUrl))
                    {
                        return Redirect(decodedUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неверный Логин или Пароль");
            }
            return View("Login", account);
        }

        public ActionResult Logout()
        {
            Authentication.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
