﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
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