using MRSTW.Database;
using System.Linq;
using System.Web.Mvc;

namespace MRSTW.Controllers
{
	public class AuthController : Controller
	{
		public ActionResult Login()
		{
			var c = new ScheduleDbContext();
			var u = c.Users.Take(2);
			return View();
		}

		public ActionResult Register()
		{
			return View();
		}
	}
}