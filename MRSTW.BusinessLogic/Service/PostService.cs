using MRSTW.BusinessLogic.Database;
using MRSTW.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class PostService : Service
	{
		public EntryServiceResponse<Post> GetPostById(int id)
		{
            using (var db = new BlogDbContext())
            {
                var post = db.Posts
                    .Include(x => x.Author)
                    .Include(x => x.Comments)
                    .Include(x => x.Reactions.Select(y => y.User))
                    .First(x => x.Id == id);

                if (post == null)
                    return Failure<EntryServiceResponse<Post>>("No Post has been found");

                return Entry(post);
            }
		}

        public EntriesServiceResponse<Post> GetAllPosts()
        {
            using (var db = new BlogDbContext())
            {
                var posts = db.Posts
                    .Include(x => x.Author)
                    .OrderByDescending(x => x.Created)
                    .ToList();

                return Entries(posts);
            }
		}

        public ServiceResponse IncrementViewCount(Post post)
        {
			using (var db = new BlogDbContext())
			{
                post.Views++;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return Success();
			}
		}
	}
}
