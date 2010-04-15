using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using BerryPatch.MVC.Controllers;
using BerryPatch.Repository;
using BerryPatch.Web;

namespace web_site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerProviderAccessor
    {
        private static IContainerResolver containerProvider;
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}.aspx/{action}/{id}",                      // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default2",                                              // Route name
                "{controller}/{action}/{id}",                            // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );            
        }

        static IContainerProvider _containerProvider;
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacControllerModule(Assembly.GetExecutingAssembly()));

            _containerProvider = new ContainerProvider(builder.Build());

            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));

            RegisterRoutes(RouteTable.Routes);
        }

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }


        protected void Application_BeginRequest()
        {
            if (Context.Request.FilePath == "/")
                Context.RewritePath("Default.aspx");
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            ContainerProvider.DisposeRequestContainer();
        }

        public static TService Resolve<TService>()
        {
            return containerProvider.Resolve<TService>(containerProvider.GetContainer());
        }

        public static readonly object lockObject = new object();
        public static void InitializeContainer(IContainerResolver containerResolver)
        {
            lock (lockObject)
            {
                containerProvider = containerResolver;
            }            
        }        
    }
}