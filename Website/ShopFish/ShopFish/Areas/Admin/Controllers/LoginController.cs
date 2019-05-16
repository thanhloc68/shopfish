using ShopFish.Models;
using ShopFish.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopFish.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(AccountViewModels.LoginViewModel model)
        {
          
            using (ShopDatabaseContext db = new ShopDatabaseContext())
            {
                var login = db.Accounts.FirstOrDefault(x => x.Usernames == model.Username && x.Roles.IDRole == 1);
                if (login != null)
                {
                    if (Crypto.VerifyHashedPassword(login.Passwords, model.Password))
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                            login.Usernames,
                            DateTime.Now,
                            DateTime.Now.AddDays(30),
                            true,
                            model.ToString(),
                            FormsAuthentication.FormsCookiePath);
                        string encTicket = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        cookie.Expires = ticket.Expiration;
                        HttpContext.Response.Cookies.Add(cookie);
                        HttpContext.Response.SetCookie(cookie);
                        return RedirectToAction("Index", "HomeAdmin");
                    }
                    else
                        ViewBag.error = "Tài khoản hoặc mật khẩu không đúng";

                }
                else
                    ViewBag.error = "Tài khoản hoặc mật khẩu không đúng";

                return View();
            }
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            //if (HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            //{
            //    HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            //    myCookie.Expires = DateTime.Now.AddDays(-30);
            //    Response.Cookies.Add(myCookie);

            //    FormsAuthentication.SignOut();

            //}

            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, FormsAuthentication.FormsCookieName);
            cookie2.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("LoginAdmin", "Login");
        }
    }
}