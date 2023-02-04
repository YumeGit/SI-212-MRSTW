using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        LessonContext db = new LessonContext();

        // GET: Home
        public ActionResult Index()
        {
            //return View(db.Lessons.Where(x => x.Name == "CDE").ToList() );
            return View(db.Lessons.ToList() ); ;
        }

        public ActionResult Rjaka(int? id)
        {
            return View(new ViewModel { TestData = id } );
        }

        public ActionResult StartRedirect()
        {
            return Redirect("/Home");
        }
    }

    public class ViewModel
    {
        public int? TestData = 1;
    }
}