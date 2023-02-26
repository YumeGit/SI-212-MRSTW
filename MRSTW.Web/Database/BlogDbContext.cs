using MRSTW.Web.Models;
using System.Data.Entity;

namespace MRSTW.Web.Database
{
	public class BlogDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
	}
}