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

namespace web_site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerProviderAccessor
    {        
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
        private static IContainer _container;

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.Register<VisitorRepository>().As<IRepository<Visitor>>().SingletonScoped();
            builder.Register<MD5Helper>().As<ICryptoHelper>().SingletonScoped();

            builder.RegisterModule(new AutofacControllerModule(Assembly.GetExecutingAssembly()));

            _container = builder.Build();
            _containerProvider = new ContainerProvider(_container);
            

            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));
            RegisterRoutes(RouteTable.Routes);
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
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        public static TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }
    }
}