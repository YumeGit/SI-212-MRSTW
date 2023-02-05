using System.Collections.Generic;

namespace MRSTW.Models
{
	public enum WeekDay
	{ 
		Monday,
		Tuesday, 
		Wednesday,
		Thursday, 
		Friday,
		Saturday, 
		Sunday
	}

	public class ScheduleElement
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
		public WeekDay WeekDay { get; set; }

		public int StartHours { get; set; }
		public int StartMinutes { get; set; }
		public int EndHours { get; set; }
		public int EndMinutes { get; set; }

		public ScheduleElement(string title, string type, WeekDay day, int sh, int sm, int eh, int em)
		{
			Title = title;
			Type = type;
			WeekDay = day;

			StartHours = sh;
			StartMinutes = sm;
			EndHours = eh;
			EndMinutes = em;
		}
	}
}