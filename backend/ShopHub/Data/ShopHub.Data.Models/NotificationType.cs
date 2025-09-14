namespace ShopHub.Data.Models
{
    public enum NotificationType
    {
        Success,
        Info,
        Warning,
        Error
    }

    public static class NotificationTypeExtensions
    {
        public static string ToValue(this NotificationType type)
        {
            return type switch
            {
                NotificationType.Success => "success",
                NotificationType.Info => "info",
                NotificationType.Warning => "warning",
                NotificationType.Error => "error",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
