using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public enum LessonType
    {
        Curs,
        Lab,
        Sem,
    }

    public enum Week
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
        Sunday1,
    }

    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NameId { get; set; }
        public LessonType Type { get; set; }
        public int TimeStartHour { get; set; }
        public int TimeStartMinute { get; set; }
        public int TimeFinishHour { get; set; }
        public int TimeFinishMinute { get; set;}
        public Week Day { get; set; }

    }

}