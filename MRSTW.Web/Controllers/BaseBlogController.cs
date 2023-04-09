using MRSTW.BusinessLogic.Service;
using MRSTW.Web.Extensions;
using System.Web.Mvc;

namespace MRSTW.Controllers
{
	public abstract class BaseBlogController : Controller
	{
		public const string SESSION_COOKIE_NAME = "SessionToken";

		public HttpStatusCodeResult HttpNoPermission() => new HttpStatusCodeResult(403);

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var sessionCookie = Request.Cookies[SESSION_COOKIE_NAME];
			if (sessionCookie == null)
				return;

			var userTest = Session.GetUser();

			using (var sessionService = new SessionService())
			{
				var token = sessionCookie.Value;
				var sessionResp = sessionService.GetByToken(token);
				if (!sessionResp.Success)
					return;

				var session = sessionResp.Entry;
				if (session == null)
					return;

				var user = session.User;
				if (user == null)
					return;

				Session.SetUser(user);
				ViewBag.SessionUser = user;
			}

			base.OnActionExecuting(filterContext);
		}
	}
}