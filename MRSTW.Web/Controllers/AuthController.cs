using MRSTW.BusinessLogic.Database;
using MRSTW.Domain;
using System;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
	public class AuthController : Controller
	{
		BlogDbContext Database;

		public AuthController()
		{
			Database = new BlogDbContext();
		}

		// GET: /Auth/Login
		public ActionResult Login()
		{
			return View();
		}

		// POST: /Auth/Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginF form)
		{
			if(ModelState.IsValid)
			{
				var data = new UserLoginData()
				{
					Email = form.Email,
					Password = form.Password,
					IpAddress = Request.UserHostAddress,
					Time = DateTime.Now
				};

				/*var userLogin = SessionBL.UserLogin(data);
				if(userLogin.Status)
				{
					return Redirect("/");
				}
				else
				{
					ModelState.AddModelError("Password", "Invalid login or password.");
				}*/
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
		public ActionResult Register(RegisterForm vm)
		{
			return View();
		}
	}
}