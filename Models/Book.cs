using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_Project.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}