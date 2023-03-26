using MRSTW.BusinessLogic.Database;
using MRSTW.BusinessLogic.Service.Response;
using MRSTW.Domain;
using System;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class AuthService : BaseService
    {
        public struct LoginData
        {
            public string Email { get; set; }
            public string Password { get; set; }    
            public string IpAddress { get; set; }
            public DateTime LoginTime { get; set; }
        }

        public ServiceResponse Login(UserLoginData data)
        {
            using (var db = new BlogDbContext())
            {
                var user = db.Users.Single(x => x.Email == data.Email);
                if (user == null)
                    return Failure("User with this email not found.");


            }
        }
    }
}
