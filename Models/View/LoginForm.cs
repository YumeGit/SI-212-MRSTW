using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MRSTW.Models.View
{
	public class LoginForm
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}