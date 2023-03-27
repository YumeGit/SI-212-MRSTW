using MRSTW.BusinessLogic.Database;
using MRSTW.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class UserService : Service
	{
        public EntryServiceResponse<User> GetById(int id)
        {
            return Entry(DbContext.Users.FirstOrDefault(x => x.Id == id));
        }

        public EntryServiceResponse<User> GetByEmail(string email)
        {
            return Entry(DbContext.Users.FirstOrDefault(x => x.Email == email));
        }

        public ServiceResponse Edit(User user)
        {
            DbContext.Entry(user).State = EntityState.Modified;
            DbContext.SaveChanges();
            return Success();
        }

        public ServiceResponse Delete(User user)
        {
            DbContext.Entry(user).State = EntityState.Deleted;
            DbContext.SaveChanges();
            return Success();
        }

        public EntriesServiceResponse<Post> GetAllUsers()
        {
            var posts = DbContext.Posts
                .ToList();

            return Entries(posts);
        }
    }
}
