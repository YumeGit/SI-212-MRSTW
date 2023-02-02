using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WEB_Project.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set;}
    }
}