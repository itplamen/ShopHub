namespace ShopHub.Services.Data
{
    using ShopHub.Service.Cache.Contracts;
    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Product;

    public class CacheDataProvider : IProductsService
    {
        private readonly IProductsService decorated;
        private readonly ICacheService<IEnumerable<ProductResponse>> cacheService;

        public CacheDataProvider(IProductsService decorated, ICacheService<IEnumerable<ProductResponse>> cacheService)
        {
            this.decorated = decorated;
            this.cacheService = cacheService;
        }

        public async Task<IEnumerable<ProductResponse>> GetAll(ProductRequest request)
        {
            IEnumerable<ProductResponse> products = await cacheService.GetOrCreateAsync($"all_{request.Page}", async () =>
            {
                var result = await decorated.GetAll(request);
                return result;
            });

            return products;
        }

        public async Task<ProductResponse> GetById(int id)
        {
            IEnumerable<ProductResponse> product = await cacheService.GetOrCreateAsync(id.ToString(), async () =>
            {
                var result = await decorated.GetById(id);
                return new List<ProductResponse>() { result };
            });

            return product.FirstOrDefault();
        }
    }
}
