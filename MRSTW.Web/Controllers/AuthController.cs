using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Web.Models;
using MRSTW.Web.Extensions;
using System;
using System.Web;
using System.Web.Mvc;

namespace Mondy.Web.Controllers
{
    public class AuthController : BaseController
    {
        // GET /Auth/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST /Auth/Login
        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                var data = new AuthService.LoginData()
                {
                    Email = form.Email,
                    Password = form.Password,
                    IpAddress = Request.UserHostAddress,
                    Time = DateTime.Now
                };

                var accountService = new AuthService();
                var loginResp = accountService.Login(data);
                if (loginResp.Success)
                {
                    var session = loginResp.Entry;

                    // Create Cookie.
                    var cookie = new HttpCookie(SESSION_COOKIE_NAME, session.Token);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);

                    return Redirect("/");
                }

                ModelState.AddModelError("Password", loginResp.Message);
            }

            return View(form);
        }

        // GET: /Auth/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                var data = new AuthService.RegisterData()
                {
                    Name = form.Name,
                    Email = form.Email,
                    Password = form.Password,
                    IpAddress = Request.UserHostAddress,
                    Time = DateTime.Now
                };

                var accountService = new AuthService();
                var resp = accountService.Register(data);
                if (!resp.Success)
                {
                    ModelState.AddModelError("", resp.Message);
                    return View(form);
                }

                return Login(new LoginForm()
                {
                    Email = form.Email,
                    Password = form.Password
                });
            }

            return View(form);
        }

        public ActionResult Logout()
        {
            // Clear session cookie.
            var cookie = Request.Cookies[SESSION_COOKIE_NAME];
            if (cookie != null)
            {
                // Force expire.
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Session.ClearUser();
            return Redirect("/");
        }
    }
}