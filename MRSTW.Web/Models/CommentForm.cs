using System.ComponentModel.DataAnnotations;

namespace MRSTW.Web.Models
{
	public class CommentForm
	{
		[Required]
		public int PostId { get; set; }
		[Required]
		[MaxLength(100)]
		public string Message { get; set; }
	}
}