using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_Project.Models
{
    public enum LessonType
    {
        Curs,
        Lab,
        Sem,
    }

    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NameId { get; set; }
        public LessonType Type { get; set; }
        public (int hour, int minute) TimeStart { get; set; }
        public (int hour, int minute) TimeFinish { get; set; }
    }
}