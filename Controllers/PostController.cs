using MRSTW.Database;
using MRSTW.Models;
using MRSTW.Models.View;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;

namespace MRSTW.Controllers
{
    public class PostController : Controller
	{
		[ActionName("View")]
		public ActionResult ViewFullPost(int id)
		{
			using (var ctx = new BlogDbContext())
			{
				var post = ctx.Posts
					.Include(x => x.Author)
					.Include(x => x.Comments)
					.FirstOrDefault();

				post.Views++;
				ctx.SaveChanges();

				return View(post);
			}
		}

		public ActionResult Comments(int id)
		{
			using (var ctx = new BlogDbContext())
			{
				var post = ctx.Posts
					.Include(parent => parent.Comments)
					.Include(x => x.Author)
					.FirstOrDefault();

				post.Comments = post.Comments
					.OrderByDescending(x => x.Created)
					.ToList();

				return View(post);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Comments(PostCommentForm form)
		{
			using (var ctx = new BlogDbContext())
			{
				var post = ctx.Posts
					.Include(x => x.Comments.Select(y => y.Author))
					.FirstOrDefault();

				// Create a new comment
				if (ModelState.IsValid)
				{
					var user = ctx.Users
						.FirstOrDefault();

					var comment = new Comment
					{
						Author = user,
						Message = form.Message
					};

					post.Comments.Add(comment);
					ctx.SaveChanges();
				}

				post.Comments = post.Comments
					.OrderByDescending(x => x.Created)
					.ToList();

				return View(post);
			}
		}
    }
}