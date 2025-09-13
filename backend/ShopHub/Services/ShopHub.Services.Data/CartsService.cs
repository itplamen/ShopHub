namespace ShopHub.Services.Data
{
    using ShopHub.Data.Contracts;
    using ShopHub.Data.Models;
    using ShopHub.Services.Data.Contracts;

    public class CartsService : ICartsService
    {
        private readonly IRepository<Cart> repository;

        public CartsService(IRepository<Cart> repository)
        {
            this.repository = repository;
        }

        public async Task Add(int userId)
        {
            await repository.AddAsync(new Cart() { UserId = userId });
        }
    }
}
