using MRSTW.Domain.Entities;
using System.Collections.Generic;

namespace MRSTW.Web.Models
{
    public class HomePageView
    {
        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
    }
}