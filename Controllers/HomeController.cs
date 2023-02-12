using MRSTW.Database;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MRSTW
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var c = new BlogDbContext())
			{
				var posts = c.Posts
					.OrderByDescending(x => x.Created)
					.Include(x => x.Author)
					.ToList();

				return View(posts);
			}
		}
	}
}