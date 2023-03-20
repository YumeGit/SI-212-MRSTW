using System;
using System.Collections.Generic;

namespace MRSTW.Web.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Story { get; set; }
		public int Views { get; set; }
		public User Author { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public ICollection<Comment> Comments { get; set; }
		public ICollection<UserReaction> Reactions { get; set; }
	}
}