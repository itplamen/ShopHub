namespace ShopHub.Services.Models.Auth
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequest : BaseAuth
    {
        [Required]
        public string DeviceId { get; set; }

        [Required]
        public string DeviceName { get; set; }
    }
}
