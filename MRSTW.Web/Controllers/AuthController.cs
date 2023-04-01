using MRSTW.BusinessLogic.Service;
using MRSTW.Web.Models;
using System;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
	public class AuthController : Controller
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

					var loginStatus = authService.Login(data);
					if(loginStatus.Success)
						return Redirect("/");

						ModelState.AddModelError("Password", loginStatus.Message);
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
					{ return Redirect("/"); }

					ModelState.AddModelError("", loginStatus.Message);
				}
			}

			return View(form);
		}
	}
}