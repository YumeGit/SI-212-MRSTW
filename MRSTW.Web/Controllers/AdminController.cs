using MRSTW.BusinessLogic.Service;
using MRSTW.Domain.Entities;
using MRSTW.Filters;
using MRSTW.Web.Extensions;
using System.Web.Mvc;

namespace MRSTW.Controllers
{
    public class AdminController : BaseController
    {
        [RequireUserRole(UserRole.Admin)]
        public ActionResult Index()
        {
            return View();
        }

        #region Posts
        [RequireUserRole(UserRole.Admin)]
        public ActionResult Posts()
        {
            using (var postService = new PostService())
            {
                var postResp = postService.GetAll();
                if (!postResp.Success)
                    return HttpNoPermission();

                var post = postResp.Entry;
                return View(post);
            }
        }

        [RequireUserRole(UserRole.Admin)]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (var postService = new PostService())
            {
                var prodResp = postService.Get(id.Value);
                if (!prodResp.Success)
                    return HttpNoPermission();

                var prod = prodResp.Entry;
                if (prod == null)
                    return HttpNotFound();

                return View(prod);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireUserRole(UserRole.Admin)]
        public ActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                using (var postService = new PostService())
                {
                    var editResp = postService.AddOrUpdate(post);
                    if (!editResp.Success)
                        return HttpNoPermission();
                }
            }

            return View(post);
        }

        [RequireUserRole(UserRole.Admin)]
        public ActionResult DeletePost(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (var postService = new PostService())
            {
                var postResp = postService.Get(id.Value);
                if (!postResp.Success)
                    return HttpNoPermission();

                var post = postResp.Entry;
                if (post == null)
                    return HttpNotFound();

                return View(post);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeletePost")]
        [RequireUserRole(UserRole.Admin)]
        public ActionResult DeletePostConfirm(int? id)
        {
            if (ModelState.IsValid)
            {
                using (var postService = new PostService())
                {
                    var prodResp = postService.Get(id.Value);
                    if (!prodResp.Success)
                        return HttpNoPermission();

                    var product = prodResp.Entry;
                    var deleteResp = postService.Remove(product);
                    if (!deleteResp.Success)
                        return HttpNoPermission();
                }
            }

            return RedirectToAction("Posts");
        }


        [RequireUserRole(UserRole.Admin)]
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireUserRole(UserRole.Admin)]
        public ActionResult CreatePost(Post product)
        {
            if (ModelState.IsValid)
            {
                using (var postService = new PostService())
                {
                    product.Author = Session.GetUser();
                    var editResp = postService.Add(product);
                    if (!editResp.Success)
                        return HttpNoPermission();
                }
            }

            return RedirectToAction("Posts");
        }
        #endregion

        #region Users
        [RequireUserRole(UserRole.Admin)]
        public ActionResult Users()
        {
            using (var userService = new UserService())
            {
                var prodResp = userService.GetAll();
                if (!prodResp.Success)
                    return HttpNoPermission();

                var prod = prodResp.Entry;
                return View(prod);
            }
        }

        [RequireUserRole(UserRole.Admin)]
        public ActionResult EditUser(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (var userService = new UserService())
            {
                var prodResp = userService.Get(id.Value);
                if (!prodResp.Success)
                    return HttpNoPermission();

                var prod = prodResp.Entry;
                if (prod == null)
                    return HttpNotFound();

                return View(prod);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireUserRole(UserRole.Admin)]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                using (var userService = new UserService())
                {
                    var editResp = userService.AddOrUpdate(user);
                    if (!editResp.Success)
                        return HttpNoPermission();
                }
            }

            return View(user);
        }

        [RequireUserRole(UserRole.Admin)]
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (var userService = new UserService())
            {
                var prodResp = userService.Get(id.Value);
                if (!prodResp.Success)
                    return HttpNoPermission();

                var post = prodResp.Entry;
                if (post == null)
                    return HttpNotFound();

                return View(post);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteUser")]
        [RequireUserRole(UserRole.Admin)]
        public ActionResult DeleteUserConfirm(int? id)
        {
            if (ModelState.IsValid)
            {
                using (var userService = new UserService())
                {
                    var prodResp = userService.Get(id.Value);
                    if (!prodResp.Success)
                        return HttpNoPermission();

                    var product = prodResp.Entry;
                    var deleteResp = userService.Remove(product);
                    if (!deleteResp.Success)
                        return HttpNoPermission();
                }
            }

            return RedirectToAction("Users");
        }
        #endregion
    }
}