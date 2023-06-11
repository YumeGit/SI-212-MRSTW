using System;
using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
	public interface IHasComments
    {
        int Id { get; set; }
        List<Comment> Comments { get; }
	}

	public class Comment : IHasComments, IHasReactions
    {
		public int Id { get; set; }
		public User Author { get; set; }
		public string Message { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;

        // IHasComments
        public List<Comment> Comments { get; set; }

        // IHasReactions
        public List<Reaction> Reactions { get; set; }
    }
}
