using MRSTW.Domain.Entities;

namespace MRSTW.Web.Models
{
    public class CategoryView
    {
        public string Name { get; set; }
        public Post[] Posts { get; set; }
    }
}