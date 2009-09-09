using Autofac;

namespace BerryPatch.Web
{
    public static class ContainerResolverExtensions
    {
        public static TService Resolve<TService>(this IContainerResolver containerResolver, IContainer container)
        {
            return container.Resolve<TService>();
        }
    }
}
