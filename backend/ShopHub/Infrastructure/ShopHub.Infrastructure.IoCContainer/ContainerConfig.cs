namespace ShopHub.Infrastructure.IoCContainer
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using ShopHub.Infrastructure.IoCContainer.Contracts;
    using ShopHub.Infrastructure.IoCContainer.Packages;

    public static class ContainerConfig
    {
        public static void AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            IPackage[] packages =
            {
                new CachePackage(configuration),
                new MappingsPackage(),
                new WebPackage(),
            };

            RegisterServices(services, packages);
        }

        private static void RegisterServices(IServiceCollection services, IPackage[] packages)
        {
            foreach (var package in packages)
            {
                package.RegisterServices(services);
            }
        }
    }
}
