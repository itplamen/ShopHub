namespace ShopHub.Services.Data
{
    using AutoMapper;

    using Microsoft.EntityFrameworkCore;
    
    using ShopHub.Data.Contracts;
    using ShopHub.Data.Models;
    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Product;

    public class ProductsService : IProductsService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Product> repository;

        public ProductsService(IMapper mapper, IRepository<Product> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<ProductResponse>> GetAll(ProductRequest request)
        {
            IEnumerable<Product> products = await repository.Filter()
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var response = mapper.Map<IEnumerable<ProductResponse>>(products);

            return response;
        }

        public async Task<ProductResponse> GetById(int id)
        {
            Product product = await repository.GetByIdAsync(id);
            var response = mapper.Map<ProductResponse>(product);

            return response;
        }
    }
}
