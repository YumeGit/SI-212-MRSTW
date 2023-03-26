﻿using MRSTW.Domain.Entities;
using System.Data.Entity;

namespace MRSTW.BusinessLogic.Database
{
	public class BlogDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<UserReaction> Reactions { get; set; }
	}
}