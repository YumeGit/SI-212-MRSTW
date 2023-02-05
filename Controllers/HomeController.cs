using MRSTW.Database;
using System.Linq;
using System.Web.Mvc;

namespace MRSTW
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var ctx = new ScheduleDbContext();
			var users = ctx.Users.ToList();
			return View(users);
		}
	}
}