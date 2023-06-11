using MRSTW.BusinessLogic.Service;
using MRSTW.Domain.Entities;
using MRSTW.Web.Extensions;
using System.Web.Mvc;

namespace MRSTW.Controllers
{
	public abstract class BaseController : Controller
	{
		public const string SESSION_COOKIE_NAME = "SessionToken";

		public HttpStatusCodeResult HttpNoPermission() => new HttpStatusCodeResult(403);

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var sessionCookie = Request.Cookies[SESSION_COOKIE_NAME];
			if (sessionCookie == null)
				return;

			using (var sessionService = new SessionService())
			{
				var token = sessionCookie.Value;
				var sessionResp = sessionService.GetByToken(token);
				if (!sessionResp.Success)
					return;

				var session = sessionResp.Entry;
				if (session == null)
					return;

				using (var userService = new UserService())
				{
                    var userResp = userService.Get(session.UserId);
                    if (!userResp.Success)
						return;

                    var user = userResp.Entry;
                    if (user == null)
                        return;

                    Session.SetUser(user);
                    ViewBag.SessionUser = user;
                }
			}

			base.OnActionExecuting(filterContext);
		}
	}
}