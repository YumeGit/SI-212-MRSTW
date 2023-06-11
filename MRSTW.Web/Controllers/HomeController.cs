using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace MRSTW.Web
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			using(var postsService = new PostService())
			{
				var postsResp = postsService.GetAll();
                if (!postsResp.Success)
                    return HttpNoPermission();

                var vm = new HomePageView
                {
                    Posts = postsResp.Entry
                };

				return View(vm);
            }
		}
	}
}