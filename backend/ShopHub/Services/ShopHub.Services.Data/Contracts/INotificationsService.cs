namespace ShopHub.Services.Data.Contracts
{
    using ShopHub.Data.Models;
    using ShopHub.Services.Models.Base;
    using ShopHub.Services.Models.Notification;

    public interface INotificationsService
    {
        Task<BaseResponse<NotificationResponse>> Get(int userId);

        Task Create(int userId, string message, NotificationType type);

        Task MarkAsRead(int id);
    }
}
