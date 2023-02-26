using System.ComponentModel.DataAnnotations;

namespace MRSTW.Web.Models.View
{
	public class PostCommentForm
	{
		[Required] public int Id { get; set; }
		[Required] public string Message { get; set; }
	}
}