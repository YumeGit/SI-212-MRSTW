using MRSTW.Domain.Entities;
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

        public ServiceResponse<Session> Login(LoginData data)
        {
            var passHash = AuthHelper.GeneratePasswordHash(data.Password);

            var user = DbContext.Users.FirstOrDefault(x => x.Email == data.Email && x.PasswordHash == passHash);
            if (user == null)
                return Failure<Session>("User with this pair not found");

            user.LastIpAddress = data.IpAddress;
            user.LastLoginTime = data.Time;
            DbContext.Entry(user).State = EntityState.Modified;

            var session = new Session()
            {
                Token = AuthHelper.GenerateSessionToken(user.Name),
                UserId = user.Id
            };

            DbContext.Sessions.Add(session);
            DbContext.SaveChanges();
            return Success(session);
        }

        public struct RegisterData
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string IpAddress { get; set; }
            public DateTime Time { get; set; }
        }

        public ServiceResponse<User> Register(RegisterData data)
        {
            if (DbContext.Users.FirstOrDefault(x => x.Email == data.Email) != null)
                return Failure<User>("Account with this Email already exists.");

            var user = new User
            {
                Name = data.Name,
                Email = data.Email,
                PasswordHash = AuthHelper.GeneratePasswordHash(data.Password),
            };

            DbContext.Users.Add(user);
            DbContext.SaveChanges();
            return Success(user);
        }
    }
}
