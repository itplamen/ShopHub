namespace ShopHub.Services.Models.Auth
{
    using System.ComponentModel.DataAnnotations;

    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
