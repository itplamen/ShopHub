namespace ShopHub.Services.Data.Contracts
{
    using ShopHub.Services.Models.Base;
    using ShopHub.Services.Models.Notification;

    public interface INotificationsService
    {
        Task<BaseResponse<NotificationResponse>> Get(int userId);

        Task Create(int userId, string message);

        Task MarkAsRead(int id);
    }
}
