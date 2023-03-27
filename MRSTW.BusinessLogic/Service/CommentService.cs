using MRSTW.Domain.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class CommentService : Service
    {
        public struct CommentForm
        {
            public User Author { get; set; }
            public string Message { get; set; }    
            public DateTime Time { get; set; }
        }

        public EntriesServiceResponse<Comment> GetAllFromPost(Post post)
        {
            DbContext.Posts.Attach(post); 

            var comments = DbContext.Entry(post)
                .Collection(x => x.Comments).Query()
                .Include(x => x.Reactions.Select(y => y.User))
                .Include(x => x.Author)
                .OrderByDescending(x => x.Created)
                .ToList();

            return Entries(comments);
        }

        public EntryServiceResponse<Comment> AddToPost(Post post, CommentForm form)
        {
            var comment = new Comment
            {
                Author = form.Author,
                Message = form.Message,
                Created = form.Time
            };

            post.Comments.Add(comment);
            DbContext.SaveChanges();

            return Entry(comment);
		}
	}
}
