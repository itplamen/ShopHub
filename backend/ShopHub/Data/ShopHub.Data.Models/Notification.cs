namespace ShopHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Notification : BaseEntity
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
