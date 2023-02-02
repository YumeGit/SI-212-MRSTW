using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WEB_Project.Models
{
    public class LessonContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set;}
    }
}