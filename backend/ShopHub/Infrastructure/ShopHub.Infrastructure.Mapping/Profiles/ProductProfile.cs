namespace ShopHub.Infrastructure.Mapping.Profiles
{
    using AutoMapper;

    using ShopHub.Data.Models;
    using ShopHub.Services.Models.Product;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}
