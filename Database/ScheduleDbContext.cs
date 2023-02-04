using MRSTW.Models;
using System.Data.Entity;

namespace MRSTW.Database
{
	/// <summary>
	/// Главный аксессор базы данных, позволяющий подгрузить данные 
	/// </summary>
	public class ScheduleDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
	}
}