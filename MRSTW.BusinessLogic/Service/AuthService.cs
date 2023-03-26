using MRSTW.BusinessLogic.Database;
using MRSTW.Helpers;
using System;
using System.Data.Entity;
using System.Linq;

namespace MRSTW.BusinessLogic.Service
{
    public class AuthService : Service
    {
        public struct LoginData
        {
            public string Email { get; set; }
            public string Password { get; set; }    
            public string IpAddress { get; set; }
            public DateTime Time { get; set; }
        }

        public ServiceResponse Login(LoginData data)
        {
            using (var db = new BlogDbContext())
            {
                var passHash = AuthHelper.GeneratePasswordHash(data.Password);

                var user = db.Users.FirstOrDefault(x => x.Email == data.Email && x.PasswordHash == passHash);
                if (user == null)
                    return Failure("User with this pair not found.");

                user.LastIpAddress = data.IpAddress;
                user.LastLoginTime = data.Time;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
               
            return Success();
		}
	}
}
