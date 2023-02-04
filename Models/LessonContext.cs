using System.Data.Entity;

namespace MRSTW.Models
{
    public class LessonContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set;}
    }
}