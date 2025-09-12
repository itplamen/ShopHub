namespace ShopHub.Data.Models
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string DeviceName { get; set; }

        public string DeviceId { get; set; }

        public string IPAddress { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
