using DonsIOCContainer;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HelloDependencyInjection.Controllers;
using HelloDependencyInjection.Services;

namespace HelloDependencyInjection
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new IocContainer();

            container.Register<HomeController, HomeController>();
            container.Register<IEmailService, EmailService>();

            ControllerBuilder.Current.SetControllerFactory(new DonsIocControllerFactory(container));
        }
    }
}