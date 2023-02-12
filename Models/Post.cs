using System;
using System.Collections.Generic;

namespace MRSTW.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ShortStory { get; set; }
		public string FullStory { get; set; }
		public int Views { get; set; }
		public User Author { get; set; }
		public DateTime Created { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}