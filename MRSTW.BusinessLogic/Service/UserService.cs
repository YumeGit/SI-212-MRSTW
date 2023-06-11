using MRSTW.Domain.Entities;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class UserService : ModelService<User>
	{
        public ServiceResponse<User> GetByEmail(string email)
        {
            return Find(x => x.Email == email);
        }
    }
}
