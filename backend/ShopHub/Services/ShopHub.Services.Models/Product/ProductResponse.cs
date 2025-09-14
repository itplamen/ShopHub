namespace ShopHub.Services.Models.Product
{
    using ShopHub.Services.Models.Contracts;

    public class ProductResponse : IResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
