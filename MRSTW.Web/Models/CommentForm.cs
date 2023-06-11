using System.ComponentModel.DataAnnotations;

namespace MRSTW.Web.Models
{
	public class CommentForm
	{
		public string Type { get; set; }
		[Required]
		public int TargetId { get; set; }
		[Required]
		[MaxLength(100)]
		public string Message { get; set; }
		public string GoBackUrl { get; set; }
	}
}