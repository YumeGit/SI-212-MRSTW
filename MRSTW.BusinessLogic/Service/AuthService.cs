using MRSTW.BusinessLogic.Database;
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

		public ServiceResponse Login(LoginData data)
		{
			var passHash = AuthHelper.GeneratePasswordHash(data.Password);

			var user = DbContext.Users.FirstOrDefault(x => x.Email == data.Email && x.PasswordHash == passHash);
			if (user == null)
				return Failure("User with this pair not found.");

			user.LastIpAddress = data.IpAddress;
			user.LastLoginTime = data.Time;
			DbContext.Entry(user).State = EntityState.Modified;
			DbContext.SaveChanges();

			return Success();
		}

		public struct RegisterData
		{
			public string Name { get; set; }
			public string Email { get; set; }
			public string Password { get; set; }
			public string IpAddress { get; set; }
			public DateTime Time { get; set; }
		}

		public ServiceResponse Register(RegisterData data)
		{
			using (var uService = new UserService())
			{
				if (uService.GetByEmail(data.Email).Entry != null)
					return Failure("Account with this Email already exists.");
			}

			var user = new User
			{
				Name = data.Name,
				Email = data.Email,
				PasswordHash = AuthHelper.GeneratePasswordHash(data.Password),
				LastIpAddress = data.IpAddress,
				LastLoginTime = data.Time,
				Role = UserRole.User
			};

			DbContext.Users.Add(user);
			DbContext.SaveChanges();
			return Success();
		}
	}
}
