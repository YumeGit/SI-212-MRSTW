using System.ComponentModel.DataAnnotations;

namespace MRSTW.Web.Models.View
{
	public class LoginForm
	{
		[Required]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}