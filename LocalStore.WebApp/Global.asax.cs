using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LocalStore.WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
