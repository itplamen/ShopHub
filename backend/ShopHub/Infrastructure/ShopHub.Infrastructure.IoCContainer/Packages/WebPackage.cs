namespace ShopHub.Infrastructure.IoCContainer.Packages
{
    using Microsoft.Extensions.DependencyInjection;

    using ShopHub.Data;
    using ShopHub.Data.Contracts;
    using ShopHub.Infrastructure.IoCContainer.Contracts;
    using ShopHub.Service.Cache.Contracts;
    using ShopHub.Services.Data;
    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Product;

    public sealed class WebPackage : IPackage
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRefreshTokensSerivce, RefreshTokensSerivce>();
            services.AddScoped<INotificationsService, NotificationsService>();
            services.AddScoped<ProductsService>();
            services.AddScoped<IProductsService>(x => x.GetRequiredService<ProductsService>());

            RegisterDecorator(services);
        }

        private void RegisterDecorator(IServiceCollection services)
        {
            services.AddScoped<IProductsService>(x =>
            {
                var productService = x.GetRequiredService<ProductsService>();
                var cacheService = x.GetRequiredService<ICacheService<IEnumerable<ProductResponse>>>();
                return new CacheDataProvider(productService, cacheService);
            });
        }

    }
}
