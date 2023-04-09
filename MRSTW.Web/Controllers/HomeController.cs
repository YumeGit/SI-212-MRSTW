using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using System.Web.Mvc;

namespace MRSTW.Web
{
	public class HomeController : BaseBlogController
	{
		public ActionResult Index()
		{
			using (var posts = new PostService())
			{
				var allPosts = posts.GetAll();
				return View(allPosts.Entries);
			}
		}
	}
}