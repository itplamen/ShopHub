namespace ShopHub.Services.Models.Notification
{
    using ShopHub.Services.Models.Contracts;

    public class NotificationResponse : IResponse
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
