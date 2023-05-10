using MRSTW.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class CategoryService : Service
	{
		public EntryServiceResponse<Category> GetById(int id)
		{
            var post = DbContext.Categories
                .First(x => x.Id == id);

            return Entry(post);
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
