using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MRSTW.Web.Models.View
{
	public class RegisterForm
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[DisplayName("Confirm Password")]
		[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again!")]
		public string PasswordConfirm { get; set; }
	}
}