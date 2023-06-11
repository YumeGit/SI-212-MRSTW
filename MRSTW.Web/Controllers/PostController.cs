using MRSTW.BusinessLogic.Service;
using MRSTW.Controllers;
using MRSTW.Domain.Entities;
using MRSTW.Filters;
using MRSTW.Web.Extensions;
using MRSTW.Web.Models;
using System.Web.Mvc;

namespace MRSTW.Web.Controllers
{
	public class PostController : BaseController
	{
		PostService Posts = new PostService();

		public ActionResult Category(string id) 
		{
			var postsResp = Posts.FindAll(x => x.CatergoryName == id);
			if (!postsResp.Success)
				return HttpNoPermission();

			return View(new CategoryView
			{
				Name = id,
				Posts = postsResp.Entry
			});
		}

		public ActionResult Details(int id)
		{
			var postResp = Posts.Get(id);
            if (!postResp.Success)
                return HttpNoPermission();

			var post = postResp.Entry;
			if (post == null)
				return HttpNotFound();

			Posts.LoadReference(post, "Author");
            return View(post);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[RequireLogin]
		public ActionResult PostComment(CommentForm form)
		{
			var commentService = new CommentService();
            IHasComments target = null;
			switch(form.Type)
			{
				case "Comment":
                    var comResp = commentService.Get(form.TargetId);
                    if (!comResp.Success)
                        return HttpNoPermission();

                    target = comResp.Entry;
					commentService.LoadCollection(comResp.Entry, "Comments");
                    break;

                case "Post":
					using (var postService = new PostService())
					{
						var postResp = postService.Get(form.TargetId);
						if (!postResp.Success)
							return HttpNoPermission();

						target = postResp.Entry;
                        postService.LoadCollection(postResp.Entry, "Comments");
                    }
					break;
            }

			if (target == null)
				return HttpNoPermission();

            var comment = new Comment { Author = Session.GetUser(), Message = form.Message };
			target.Comments.Add(comment);
			commentService.Add(comment);
			return Redirect(form.GoBackUrl);
		}

		[RequireLogin]
		[ValidateInput(false)]
		public ActionResult ToggleReaction(ReactionForm form)
        {
            var reactionService = new ReactionService();
            IHasReactions target = null;
            switch (form.Type)
            {
                case "Comment":
                    using (var commentService = new CommentService())
                    {
                        var comResp = commentService.Get(form.TargetId);
                        if (!comResp.Success)
                            return HttpNoPermission();

                        target = comResp.Entry;
                        commentService.LoadCollection(comResp.Entry, "Reactions");
                    }
                    break;

                case "Post":
                    using (var postService = new PostService())
                    {
                        var postResp = postService.Get(form.TargetId);
                        if (!postResp.Success)
                            return HttpNoPermission();

                        target = postResp.Entry;
                        postService.LoadCollection(postResp.Entry, "Reactions");
                    }
                    break;
            }

			var author = Session.GetUser();
			var existingReaction = target.Reactions.Find(x => x.Author == author && x.Emoji == form.Emoji);
			if(existingReaction != null)
			{
				// Delete 
				target.Reactions.Remove(existingReaction);
				reactionService.Delete(existingReaction);
			}
			else
            {
				// Create
                var reaction = new Reaction { Author = Session.GetUser(), Emoji = form.Emoji };
                target.Reactions.Add(reaction);
                reactionService.Add(reaction);
            }

            return Redirect(form.GoBackUrl);
		}
	}
}