namespace ShopHub.Infrastructure.Mapping.Profiles
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;

    using ShopHub.Services.Models.Base;

    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<IdentityResult, BaseResponse>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.Succeeded))
                .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors.Select(e => e.Description).ToList()));
        }
    }
}
