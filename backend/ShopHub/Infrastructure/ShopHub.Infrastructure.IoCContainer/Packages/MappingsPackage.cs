namespace ShopHub.Infrastructure.IoCContainer.Packages
{
    using Microsoft.Extensions.DependencyInjection;
    
    using ShopHub.Infrastructure.IoCContainer.Contracts;
    using ShopHub.Infrastructure.Mapping.Profiles;

    public sealed class MappingsPackage : IPackage
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
        }
    }
}
