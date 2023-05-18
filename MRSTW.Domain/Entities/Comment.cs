using MRSTW.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
	public class Comment : IHasComments, IHasReactions
    {
		public int Id { get; set; }
		public string Message { get; set; }
		public User Author { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public List<Reaction> Reactions { get; set; }
		public List<Comment> Comments { get; set; }
	}
}