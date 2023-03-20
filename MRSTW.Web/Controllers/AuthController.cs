using MRSTW.BusinessLogic.Database;
using MRSTW.Domain;
using MRSTW.Web.Models.View;
using System;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
	public class AuthController : Controller
	{
		BlogDbContext Database;
		// readonly ISession SessionBL;

		public AuthController()
		{
			Database = new BlogDbContext();
			// SessionBL = new BusinessLogic.BusinessLogic().GetSessionBL();
		}

		// GET: /Auth/Login
		public ActionResult Login()
		{
			return View();
		}

		// POST: /Auth/Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginForm form)
		{
			if(ModelState.IsValid)
			{
				var data = new LoginData()
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