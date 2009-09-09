﻿using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using BerryPatch.Repository;
using BerryPatch.Repository.Security;

namespace BerryPatch.Web
{
    public class WebSiteContainer: IContainerResolver
    {
        private readonly IContainer container;
        private readonly ContainerProvider containerProvider;

        public WebSiteContainer()
        {
            var builder = new ContainerBuilder();
            builder.Register<VisitorRepository>().As<IRepository<Visitor>>().SingletonScoped();
            builder.Register<MD5Helper>().As<ICryptoHelper>().SingletonScoped();

            builder.RegisterModule(new AutofacControllerModule(Assembly.GetExecutingAssembly()));

            this.container = builder.Build();
            this.containerProvider = new ContainerProvider(container);
            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(containerProvider));
        }

     
        public IContainer GetContainer()
        {
            return container;
        }

        public void Dispose()
        {
            containerProvider.DisposeRequestContainer();
        }

        public IContainerProvider GetContainerProvider()
        {
            return containerProvider;
        }
    }    
}