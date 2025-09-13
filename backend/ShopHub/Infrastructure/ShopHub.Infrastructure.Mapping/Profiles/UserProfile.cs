namespace ShopHub.Infrastructure.Mapping.Profiles
{
    using AutoMapper;
    
    using ShopHub.Data.Models;
    using ShopHub.Services.Models.Auth;


    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
