using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace MRSTW
{
    public class AppConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
		{
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
