using MRSTW.Domain.Entities;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class PostService : Service
	{
	    public EntryServiceResponse<Post> GetById(int id)
	    {
            var post = DbContext.Posts
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Include("Reactions.Author")
                .First(x => x.Id == id);

            if (post == null) 
                return Entry(post);

            // Recursively load comment threads
            if (post.Comments != null)
            {
                foreach (var comment in post.Comments)
                    RecursivelyLoadRelatedComments(comment);
            }

            return Entry(post);
	    }

		private void RecursivelyLoadRelatedComments(Comment comment)
        {
            DbContext.Entry(comment).Reference("Author").Load();
            DbContext.Entry(comment).Collection("Reactions").Load();
            DbContext.Entry(comment).Collection("Comments").Load();

            foreach(var comment2 in comment.Comments)
            {
                RecursivelyLoadRelatedComments(comment2);
            }
        }

        public EntriesServiceResponse<Post> GetAll()
        {
            var posts = DbContext.Posts
                .Include(x => x.Author)
                .OrderByDescending(x => x.Created)
                .ToList();

            return Entries(posts);
		}

        public ServiceResponse IncrementViewCount(Post post)
        {
            post.Views++;

            DbContext.Entry(post).State = EntityState.Modified;
            DbContext.SaveChanges();
            return Success();
		}

		public ServiceResponse Edit(Post post)
		{
			post.Story = post.Story.Trim();

			DbContext.Entry(post).State = EntityState.Modified;
			DbContext.SaveChanges();
			return Success();
		}

		public ServiceResponse Delete(Post post)
		{
			DbContext.Entry(post).State = EntityState.Deleted;
			DbContext.SaveChanges();
			return Success();
		}

        public EntriesServiceResponse<Post> GetAllFromCategory(Category category)
        {
            DbContext.Categories.Attach(category);

            var comments = DbContext.Entry(category)
                .Collection(x => x.Posts).Query()
                .Include(x => x.Author)
                .OrderByDescending(x => x.Created)
                .ToList();

            return Entries(comments);
        }
    }
}
