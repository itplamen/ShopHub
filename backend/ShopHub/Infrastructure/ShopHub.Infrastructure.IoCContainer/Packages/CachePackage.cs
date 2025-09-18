namespace ShopHub.Infrastructure.IoCContainer.Packages
{
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    
    using ShopHub.Infrastructure.IoCContainer.Contracts;
    using ShopHub.Service.Cache;
    using ShopHub.Service.Cache.Contracts;
    using ShopHub.Services.Models.Contracts;
    using ShopHub.Services.Models.Product;

    public sealed class CachePackage : IPackage
    {
        private bool useInMemoryCache;
        private int absoluteExpiration;
        private readonly IConfiguration configuration;
        public CachePackage(IConfiguration configuration)
        {
            this.configuration = configuration;
            useInMemoryCache = bool.Parse(configuration["Cache:UseInMemoryCache"]);
            absoluteExpiration = int.Parse(configuration["Cache:AbsoluteExpiration"]);
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            RegisterCacheService<IEnumerable<ProductResponse>>(services);

            if (!useInMemoryCache)
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.InstanceName = "BlazeAstroDb";
                    options.Configuration = configuration["Cache:ConnectionStrings:Redis"];
                });
            }
        }

        private void RegisterCacheService<TValue>(IServiceCollection services)
            where TValue : class, IEnumerable<IResponse>
        {
            if (useInMemoryCache)
            {
                services.AddSingleton<ICacheService<TValue>, InMemoryCacheService<TValue>>(x =>
                new InMemoryCacheService<TValue>(
                    x.GetRequiredService<IMemoryCache>(),
                    absoluteExpiration));
            }
            else
            {
                services.AddTransient<ICacheService<TValue>, DistributedCacheService<TValue>>(x =>
                new DistributedCacheService<TValue>(
                    x.GetRequiredService<IDistributedCache>(),
                    absoluteExpiration));
            }
        }
    }
}
