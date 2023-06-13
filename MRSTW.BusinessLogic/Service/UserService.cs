using MRSTW.Domain.Entities;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class UserService : ModelService<User>
	{
        public override ServiceResponse<User> Remove(User model)
        {
            return base.Remove(model);
        }
        public ServiceResponse<User> GetByEmail(string email)
        {
            return Find(x => x.Email == email);
        }
    }
}
