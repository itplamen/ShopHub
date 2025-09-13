namespace ShopHub.Services.Data.Contracts
{
    using ShopHub.Services.Models.Product;

    public interface IProductsService
    {
        Task<IEnumerable<ProductResponse>> GetAll(ProductRequest request);

        Task<ProductResponse> GetById(int id);
    }
}
