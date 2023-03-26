using MRSTW.BusinessLogic.Database;
using MRSTW.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
	public class PostService : Service
	{
		BlogDbContext DbContext = new BlogDbContext();

		public EntryServiceResponse<Post> GetPostById(int id)
		{
            var post = DbContext.Posts
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Include(x => x.Reactions.Select(y => y.User))
                .First(x => x.Id == id);

            return Entry(post);
	}

        public EntriesServiceResponse<Post> GetAllPosts()
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
			// Trim the story content.
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

		public ServiceResponse LoadComments(Post post)
		{
			post.Comments = DbContext.Entry(post)
				.Collection(x => x.Comments).Query()
				.Include(x => x.Reactions.Select(y => y.User))
				.Include(x => x.Author)
				.ToList();

			return Success();
		}
	}
}
