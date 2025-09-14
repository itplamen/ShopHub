namespace ShopHub.Service.Cache.Contracts
{
    using ShopHub.Services.Models.Contracts;

    public interface ICacheService<TValue>
        where TValue : class, IEnumerable<IResponse>
    {
        Task<TValue> GetOrCreateAsync(string key, Func<Task<TValue>> factory);
    }
}
