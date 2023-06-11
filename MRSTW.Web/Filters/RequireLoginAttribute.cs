using MRSTW.Web.Extensions;
using System.Web.Mvc;

namespace MRSTW.Filters
{
	public class RequireLoginAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var session = filterContext.HttpContext.Session;
			if (!session.IsUserLoggedIn()) 
			{
				// No permission - show 403 page.
				filterContext.Result = new RedirectResult("/Auth/Login");
				return;
			}
		}
	}
}