using MRSTW.Database;
using MRSTW.Models;
using MRSTW.Models.View;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using WebGrease.Css.Ast.Animation;

namespace MRSTW.Controllers
{
    public class PostController : Controller
	{
		BlogDbContext DbContext { get; set; } = new BlogDbContext();

		public ActionResult Details(int? id)
		{
			// Id was not provided.
			if (id == null)
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

			// Find the post entry in the database, also load the author entry,
			// and all the comments.
			var post = DbContext.Posts
				.Include(x => x.Author)
				.Include(x => x.Comments)
				.First(x => x.Id == id);

			// If we didn't find a post - bail.
			if (post == null)
				return HttpNotFound();

			// Increase the viewcount.
			post.Views++;
			// And save the changes in the database.
			DbContext.SaveChanges();

			// Show the full story of the post.
			return View(post);
		}

		public ActionResult Comments(int? id)
		{
			// Id was not provided.
			if (id == null)
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			
			// Fetch the post entry 
			var post = DbContext.Posts
				.Include(x => x.Comments.Select(y => y.Author))
				.First(x => x.Id == id);

			// Sort comments by their creation date.
			post.Comments = post.Comments
				.OrderByDescending(x => x.Created)
				.ToList();

			return View(post);
	}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Comments(PostCommentForm form)
        {
            var post = DbContext.Posts
				.Include(x => x.Comments.Select(y => y.Author))
				.First(x => x.Id == form.Id);

			// Post was not found.
			if (post == null)
				return HttpNotFound();

			// Create a new comment
			if (ModelState.IsValid)
			{
				var user = DbContext.Users
					.FirstOrDefault();

				var comment = new Comment
				{
					Author = user,
						Message = form.Message
					};

					post.Comments.Add(comment);
					DbContext.SaveChanges();
				}

				post.Comments = post.Comments
					.OrderByDescending(x => x.Created)
					.ToList();

				return View(post);
        }

        public ActionResult Edit(int? id)
        {
            // Id was not provided.
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var post = DbContext.Posts
                .First(x => x.Id == id);

			// Post was not found.
			if (post == null)
				return HttpNotFound();

            return View(post);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Story")] Post post)
        {
            if (ModelState.IsValid)
            {
				// Trim the story content.
				post.Story = post.Story.Trim();

                DbContext.Entry(post).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("Details", new { post.Id } );
            }

            return View(post);
        }

		public ActionResult Delete(int? id)
		{
			// Id was not provided.
			if (id == null)
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

			// Fetch post entry.
			var post = DbContext.Posts
				.First(x => x.Id == id);

			// Post was not found.
			if (post == null)
				return HttpNotFound();

			return View(post);
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                DbContext.Dispose();

            base.Dispose(disposing);
        }
    }
}