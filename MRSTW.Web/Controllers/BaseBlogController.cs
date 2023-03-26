using System.Web.Mvc;

namespace MRSTW.Controllers
{
	public abstract class BaseBlogController : Controller
	{
		public HttpStatusCodeResult HttpNoPermission() => new HttpStatusCodeResult(403);
	}
}