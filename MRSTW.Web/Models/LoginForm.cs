using System.ComponentModel.DataAnnotations;

namespace MRSTW.Web.Models
{
	public class LoginForm
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}