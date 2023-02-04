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
			var a = c.Users.Take(2);
			foreach(var b in a)
			{
				b.Name = b.Name;
			}
			return View();
		}

		public ActionResult Register()
		{
			return View();
		}
	}
}