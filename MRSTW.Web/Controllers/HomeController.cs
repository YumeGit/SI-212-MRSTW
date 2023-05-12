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
			var posts = new PostService();
			var categories = new CategoryService();

            var postsResp = posts.GetAll();
            if (!postsResp.Success)
                return HttpNoPermission();

            var categoryResp = categories.GetAll();
            if (!categoryResp.Success)
                return HttpNoPermission();

            var vm = new HomePageView
			{
				Posts = postsResp.Entries.ToList(),
				Categories = categoryResp.Entries.ToList()
            };

			return View(vm);
		}
	}
}