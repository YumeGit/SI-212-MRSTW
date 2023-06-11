using System;
using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
    public interface IHasReactions
    {
        int Id { get; set; }
        List<Reaction> Reactions { get; }
    }

    public class Reaction
	{
		public int Id { get; set; }
		public User Author { get; set; }
		public string Emoji { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}