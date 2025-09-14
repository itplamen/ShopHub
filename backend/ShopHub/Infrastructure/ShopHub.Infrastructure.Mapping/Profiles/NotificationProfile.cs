namespace ShopHub.Infrastructure.Mapping.Profiles
{
    using AutoMapper;

    using ShopHub.Data.Models;
    using ShopHub.Services.Models.Notification;

    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToValue()))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn));
        }
    }
}
