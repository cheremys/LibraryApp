using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LibraryBLL.Infrastructure;
using LibraryWeb.Util;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace LibraryWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // dependency injection
            NinjectModule bookModule = new BookModule();
            NinjectModule categoryModule = new CategoryModule();
            NinjectModule serviceModule = new ServiceModule();

            var kernel = new Ninject.StandardKernel(bookModule, categoryModule, serviceModule);
            //you just unbind ninject validator and there should be no collision with default validator.
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new Ninject.Web.Mvc.NinjectDependencyResolver(kernel));
        }
    }
}
