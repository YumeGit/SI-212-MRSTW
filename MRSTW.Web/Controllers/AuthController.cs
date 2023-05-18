using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Web.Extensions;
using MRSTW.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
	public class AuthController : BaseBlogController
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
			if(ModelState.IsValid)
			{

				using (var authService = new AuthService())
				{
					var data = new AuthService.LoginData()
					{
						Email = form.Email,
						Password = form.Password,
						IpAddress = Request.UserHostAddress,
						Time = DateTime.Now
					};

					var loginResp = authService.Login(data);
					if(loginResp.Success)
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
				using (var authService = new AuthService())
				{
					var data = new AuthService.RegisterData()
					{
						Name = form.Name,
						Email = form.Email,
						Password = form.Password,
						IpAddress = Request.UserHostAddress,
						Time = DateTime.Now
					};

					var loginStatus = authService.Register(data);
					if (loginStatus.Success)
					{ 
						return RedirectToAction("Login"); 
					}

					ModelState.AddModelError("", loginStatus.Message);
				}
			}

			return View(form);
		}

		public ActionResult Logout()
		{
			// Clear session cookie.
			var cookie = Request.Cookies[SESSION_COOKIE_NAME];
			if(cookie != null)
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