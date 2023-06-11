using System;
using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
	public class Post : IHasComments, IHasReactions
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Story { get; set; }
		public User Author { get; set; }
        public int Views { get; set; }
		public string Thumbnail { get; set; }
		public string CatergoryName { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;

        // IHasComments
        public List<Comment> Comments { get; set; }

        // IHasReactions
        public List<Reaction> Reactions { get; set; }
    }
}