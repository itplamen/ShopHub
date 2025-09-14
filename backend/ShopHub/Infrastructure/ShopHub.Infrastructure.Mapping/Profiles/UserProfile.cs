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

            CreateMap<User, LoginResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        }
    }
}
