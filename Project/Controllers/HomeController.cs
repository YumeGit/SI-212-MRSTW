using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            return View(new CringeData { id = id });
        }

        public ActionResult Cringe()
        {
            return View();
        }
	}

	public class CringeData
	{
		public int? id;
	}
}
