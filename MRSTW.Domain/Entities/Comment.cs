using System;
using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
	public class Comment
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public User Author { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public ICollection<Reaction> Reactions { get; set; }
	}
}