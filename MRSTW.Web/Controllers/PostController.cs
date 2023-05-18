﻿using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Domain.Entities;
using MRSTW.Filters;
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

		[RequireUserRole(UserRole.Admin)]
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
		[RequireUserRole(UserRole.Admin)]
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

		[RequireUserRole(UserRole.Admin)]
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
		[RequireUserRole(UserRole.Admin)]
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult PostComment(CommentForm form)
        {
			return View();
        }
	}
}