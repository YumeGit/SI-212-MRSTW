using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace MRSTW.Web
{
	public class HomeController : BaseBlogController
	{
		public ActionResult Index()
		{
			using (var posts = new PostService())
			{
				var postsResp = posts.GetAll();
				if(!postsResp.Success)
					return HttpNoPermission();

				var vm = new HomePageView
				{
					Posts = postsResp.Entries.ToList()
				};

				return View(vm);
			}
		}
	}
}