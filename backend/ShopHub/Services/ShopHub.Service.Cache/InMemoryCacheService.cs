namespace ShopHub.Service.Cache
{
    using Microsoft.Extensions.Caching.Memory;

    using ShopHub.Service.Cache.Contracts;
    using ShopHub.Services.Models.Contracts;

    public class InMemoryCacheService<TValue> : ICacheService<TValue>
        where TValue : class, IEnumerable<IResponse>
    {
        private readonly IMemoryCache memoryCache;
        private readonly MemoryCacheEntryOptions options;

        public InMemoryCacheService(IMemoryCache memoryCache, int expiration)
        {
            this.memoryCache = memoryCache;
            this.options = new MemoryCacheEntryOptions();
            options.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expiration);
        }

        public async Task<TValue> GetOrCreateAsync(string key, Func<Task<TValue>> factory)
        {
            return await memoryCache.GetOrCreateAsync(key, async entry =>
            {
                var value = await factory();
                return value;
            });
        }
    }
}