using MRSTW.Domain.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class CommentService : Service
    {
        public EntryServiceResponse<Comment> GetById(int id)
        {
            var comment = DbContext.Comments
                .Include(x => x.Author)
                .First(x => x.Id == id);

            return Entry(comment);
        }

        public EntriesServiceResponse<Comment> GetAllFromPost(Post post)
        {
            DbContext.Posts.Attach(post); 

            var comments = DbContext.Entry(post)
                .Collection(x => x.Comments).Query()
                .Include(x => x.Reactions.Select(y => y.Author))
                .Include(x => x.Author)
                .OrderByDescending(x => x.Created)
                .ToList();

            return Entries(comments);
        }

        public EntryServiceResponse<Comment> AddToPost(Post post, Comment comment)
        {
            post.Comments.Add(comment);
            DbContext.SaveChanges();

            return Entry(comment);
		}
	}
}
