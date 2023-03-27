using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Domain.Entities;
using MRSTW.Web.Models;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Linq;

namespace MRSTW.Web.Controllers
{
	public class PostController : BaseBlogController
	{
		PostService Posts = new PostService();

		public ActionResult Details(int? id)
		{
			if (id == null)
				return HttpNotFound();

			// Find the post entry in the database, also load the author entry,
			// and all the comments.
			var postResponse = Posts.GetById(id.Value);
			if (!postResponse.Success)
				return HttpNoPermission();

			var post = postResponse.Entry;
			if (post == null)
				return HttpNotFound();

			Posts.IncrementViewCount(post);

			// Show the full story of the post.
			return View(post);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
				return HttpNotFound();

			var post = Posts.GetById(id.Value);
			if (!post.Success)
				return HttpNoPermission();

			if (post == null)
				return HttpNotFound();

			return View(post.Entry);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Story")] Post post)
		{
			if (ModelState.IsValid)
			{
				var r = Posts.Edit(post);
				if (r.Success)
					return RedirectToAction("Details");

				return HttpNoPermission();
			}

			return View(post);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
				return HttpNotFound();

			var post = Posts.GetById(id.Value);
			if (!post.Success)
				return HttpNoPermission();

			if (post == null)
				return HttpNotFound();

			return View(post.Entry);
		}

		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeleteConfirmed(int? id)
		{
			if (id == null)
				return HttpNotFound();

			var resp = Posts.GetById(id.Value);
			if(!resp.Success)
				return HttpNoPermission();

			var post = resp.Entry;
			if (post == null)
				return HttpNotFound();

			var delResp = Posts.Delete(post);
			if(!delResp.Success)
				return HttpNoPermission();

			return Redirect("/");
		}

		public ActionResult Comments(int? id)
		{
			if (id == null)
				return HttpNotFound();

			var resp = Posts.GetById(id.Value);
			if(!resp.Success)
				return HttpNoPermission();

			var post = resp.Entry;
			using (var commentsService = new CommentService())
			{
				var comResp = commentsService.GetAllFromPost(post);
				if(!comResp.Success)
					return HttpNoPermission();

				return View(post);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Comments(CommentForm form)
        {
            var postResp = Posts.GetById(form.PostId);
            if (!postResp.Success)
                return HttpNoPermission();

            var post = postResp.Entry;
            if (post == null)
                return HttpNotFound();

            if (ModelState.IsValid)
			{
				using (var commentsService = new CommentService()) 
				{
					{
						var comResp = commentsService.GetAllFromPost(post);
						if (!comResp.Success)
							return HttpNoPermission();
					}

                    var data = new CommentService.CommentForm()
					{
						Message = form.Message,
						Author = new UserService().GetById(1).Entry,
						Time = DateTime.Now
					};


					{
						var comResp = commentsService.AddToPost(post, data);
						if(!comResp.Success)
							return HttpNoPermission();
					}

					post.Comments = post.Comments.OrderByDescending(x => x.Created).ToList();
				}
			}

			return View(post);
        }
	}
}