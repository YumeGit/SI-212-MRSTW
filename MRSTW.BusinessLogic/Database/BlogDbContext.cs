using MRSTW.Domain.Entities;
using System.Data.Entity;

namespace MRSTW.BusinessLogic.Database
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext()
			: base("name=MRSTW") { }

		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}