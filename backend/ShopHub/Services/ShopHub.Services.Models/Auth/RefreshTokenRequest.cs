namespace ShopHub.Services.Models.Auth
{
    using System.ComponentModel.DataAnnotations;

    public class RefreshTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
