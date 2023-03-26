using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Domain.Entities;
using MRSTW.Web.Models;
using System.Web.Mvc;

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
			var postResponse = Posts.GetPostById(id.Value);
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

			var post = Posts.GetPostById(id.Value);
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

			var post = Posts.GetPostById(id.Value);
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

			var resp = Posts.GetPostById(id.Value);
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

			var resp = Posts.GetPostById(id.Value);
			if(!resp.Success)
				return HttpNoPermission();

			var post = resp.Entry;
			if (Posts.LoadComments(post).Success == false) 
				return HttpNoPermission();

			return View(post);
	}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Comments(CommentForm form)
		{
			if (ModelState.IsValid)
			{
				var postResp = Posts.GetPostById(form.PostId);
				if(!postResp.Success)
					return HttpNoPermission();

				var post = postResp.Entry;
				if (post == null)
					return HttpNotFound();

				var comment = new Comment
				{
					Message = form.Message,
					Author = 
				};
			}

			return View();
        }
	}
}