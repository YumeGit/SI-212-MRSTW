using MRSTW.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
	public class Post : IHasComments, IHasReactions
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Story { get; set; }
		public int Views { get; set; }
		public string Thumbnail { get; set; }
		public User Author { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
        public List<Comment> Comments { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}