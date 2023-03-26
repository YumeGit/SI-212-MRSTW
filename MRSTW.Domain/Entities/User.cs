using System;

namespace MRSTW.Domain.Entities
{
	public enum UserRole
	{
		Guest,
		User,
		Admin
	}

	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string PasswordHash { get; set; }
		public string LastIpAddress { get; set; }
		public DateTime LastLoginTime { get; set; }
		public UserRole Role { get; set; }
	}
}