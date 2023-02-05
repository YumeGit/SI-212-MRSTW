using MRSTW.Models;
using System.Data.Entity;

namespace MRSTW.Database
{
	public class ScheduleDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<ScheduleElement> Elements { get; set; }
	}
}