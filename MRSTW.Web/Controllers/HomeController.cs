using MRSTW.BusinessLogic.Service;
using System.Web.Mvc;

namespace MRSTW.Web
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var posts = new PostService())
			{
				var allPosts = posts.GetAllPosts();
				return View(allPosts.Entries);
			}
		}
	}
}