using System.Collections.Generic;

namespace MRSTW.Domain.Entities
{
    public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}