using System.ComponentModel.DataAnnotations;

namespace MRSTW.Models.View
{
	public class PostCommentForm
	{
		[Required]
		public string Message { get; set; }
	}
}