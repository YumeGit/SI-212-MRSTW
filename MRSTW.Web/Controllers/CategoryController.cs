using MRSTW.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSTW.Controllers
{
    public class CategoryController : BaseBlogController
    {
        CategoryService Categories = new CategoryService();

        // GET: Category
        public ActionResult Details(int id)
        {
            var catResp = Categories.GetById(id);
            if (!catResp.Success)
                return HttpNotFound();

            var category = catResp.Entry;

            var postsService = new PostService();
            var postsResp = postsService.GetAllFromCategory(category);

            return View(postsResp.Entries);
        }
    }
}