using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MRSTW.Models
{
    public class LessonDbInitializer : DropCreateDatabaseAlways<LessonContext>
    {
        protected override void Seed(LessonContext db)
        {
            db.Lessons.Add(new Lesson
            {
                Name = "MN",
                NameId = 5,
                Type = LessonType.Curs,
                TimeStartHour = 8,
                TimeStartMinute = 15,
                TimeFinishHour = 12,
                TimeFinishMinute = 15,
                Day = Week.Saturday,
            } );

            db.Lessons.Add(new Lesson
            {
                Name = "CDE",
                Type = LessonType.Lab,
                NameId = 21,
                TimeStartHour = 17,
                TimeStartMinute = 00,
                TimeFinishHour = 20,
                TimeFinishMinute = 15,
                Day = Week.Wednesday,
            } );

            base.Seed(db);
        }
    }
}