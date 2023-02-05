using MRSTW.Models;
using System.Data.Entity;

namespace MRSTW.Database
{
	public class ScheduleDbInitializer: DropCreateDatabaseIfModelChanges<ScheduleDbContext>
	{
		protected override void Seed(ScheduleDbContext context)
		{
			context.Groups.Add(new Group()
			{
				Id = 1,
				Name = "SI-212",
				Members = new User[]
				{
					new User() { Email = "daniil.basiuc-brinzei@isa.utm.md", Name = "Daniel-Basiuc-Brinzei", Password = "asdf1" },
				},
				Schedule = new ScheduleElement[]
				{
					// MONDAY
					new ScheduleElement("LFAF", "Семинар",		WeekDay.Monday,  9, 45, 11, 15),
					new ScheduleElement("AC",   "Лабораторная", WeekDay.Monday, 11, 30, 13, 00),
					new ScheduleElement("WEB",  "Лабораторная", WeekDay.Monday, 13, 30, 15, 00),
					new ScheduleElement("WEB",  "Курс",         WeekDay.Monday, 15, 15, 16, 45),
					new ScheduleElement("WEB",  "Курс",         WeekDay.Monday, 17,  0, 18, 30),
					
					// TUESDAY
					new ScheduleElement("AMS",  "Лабораторная",	WeekDay.Tuesday, 15, 15, 16, 45),
					new ScheduleElement("CN",	"Лабораторная", WeekDay.Tuesday, 17,  0, 18, 30),
				}
			}) ;

			base.Seed(context);
		}
	}
}