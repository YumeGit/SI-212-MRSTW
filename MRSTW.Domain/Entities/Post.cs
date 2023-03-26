﻿using System;
using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
	public class Post
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Story { get; set; }
		public int Views { get; set; }
		public User Author { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public List<Comment> Comments { get; set; }
		public List<UserReaction> Reactions { get; set; }
	}
}