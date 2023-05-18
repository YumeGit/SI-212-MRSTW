using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Domain.Entities;
using MRSTW.Filters;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
    public class UsersController : BaseBlogController
    {
        UserService Users = new UserService();

        public ActionResult Index()
		{
			var allUsers = Users.GetAll();
            if (!allUsers.Success)
                return HttpNoPermission();

			return View(allUsers.Entries);
		}

        // GET: Users/Details/5
        [RequireUserRole(UserRole.Admin)]
        public ActionResult Details(int? id)
        {
            var userResp = Users.GetById(id.Value);
            if(!userResp.Success)
                return HttpNoPermission();

            var user = userResp.Entry;
            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        // GET: Users/Edit/5
        [RequireUserRole(UserRole.Admin)]
        public ActionResult Edit(int? id)
        {
            var userResp = Users.GetById(id.Value);
            if (!userResp.Success)
                return HttpNoPermission();

            var user = userResp.Entry;
            if (user == null)
                return HttpNotFound();

            return View(user);
        }

#if false

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }


        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Name,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
#endif
    }
}
