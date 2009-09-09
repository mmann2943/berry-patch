using System;
using Autofac;
using Autofac.Integration.Web;

namespace BerryPatch.Web
{
    public interface IContainerResolver: IDisposable
    {        
        IContainer GetContainer();
        IContainerProvider GetContainerProvider();
    }
}