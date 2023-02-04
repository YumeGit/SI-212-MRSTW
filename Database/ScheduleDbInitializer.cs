using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MRSTW.Database
{
	public class ScheduleDbInitializer: DropCreateDatabaseAlways<ScheduleDbContext>
	{
		protected override void Seed(ScheduleDbContext context)
		{
			context.Users.Add(new Models.User { Id = 2, Name = "Cringe" });
			base.Seed(context);
		}
	}
}