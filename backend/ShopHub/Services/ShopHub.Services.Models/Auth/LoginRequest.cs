namespace ShopHub.Services.Models.Auth
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequest : BaseAuthRequest
    {
        [Required]
        public string DeviceId { get; set; }

        [Required]
        public string DeviceName { get; set; }
    }
}
