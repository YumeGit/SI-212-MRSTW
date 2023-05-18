using MRSTW.Domain.Entities;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace MRSTW.BusinessLogic.Service
{
	public class CategoryService : Service
    {
        public EntryServiceResponse<Category> GetById(int id)
        {
            var post = DbContext.Categories
                .FirstOrDefault(x => x.Id == id);

            return Entry(post);
        }

        public EntryServiceResponse<Category> GetByName(string name)
        {
            var post = DbContext.Categories
                .FirstOrDefault(x => x.Name == name);

            return Entry(post);
        }

        public EntryServiceResponse<Category> GetWithPost(Post post)
        {
            var cat = DbContext.Categories
                .Where(x => x.Posts.Contains(post))
                .FirstOrDefault();

            return Entry(cat);
        }

        public EntriesServiceResponse<Category> GetAll()
        {
            var posts = DbContext.Categories
                .ToList();

            return Entries(posts);
		}

		public ServiceResponse Edit(Category post)
		{
			DbContext.Entry(post).State = EntityState.Modified;
			DbContext.SaveChanges();
			return Success();
		}

		public ServiceResponse Delete(Category post)
		{
			DbContext.Entry(post).State = EntityState.Deleted;
			DbContext.SaveChanges();
			return Success();
		}
	}
}
