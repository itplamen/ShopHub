namespace ShopHub.Services.Data
{
    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    using ShopHub.Data.Contracts;
    using ShopHub.Data.Models;
    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Base;
    using ShopHub.Services.Models.Notification;

    public class NotificationsService : INotificationsService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Notification> repository;

        public NotificationsService(IMapper mapper, IRepository<Notification> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<BaseResponse<NotificationResponse>> Get(int userId)
        {
            Notification notification = await repository.Filter()
                .Where(x => x.UserId == userId && x.DeletedOn == null)
                .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefaultAsync();

            var response = mapper.Map<NotificationResponse>(notification);

            return new BaseResponse<NotificationResponse> { Data = response };
        }

        public async Task Create(int userId, string message, NotificationType type)
        {
            var notification = new Notification()
            {
                UserId = userId,
                Message = message,
                Type = type
            };

            await repository.AddAsync(notification);
            await repository.SaveChangesAsync();
        }

        public async Task MarkAsRead(int id)
        {
            Notification notification = await repository.GetByIdAsync(id);

            if (notification != null)
            {
                notification.DeletedOn = DateTime.UtcNow;
                repository.Update(notification);

                await repository.SaveChangesAsync();
            }
        }
    }
}
