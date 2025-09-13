namespace ShopHub.Services.Models.Auth
{
    using ShopHub.Services.Models.Contracts;

    public class RefreshTokenResponse : TokenResponse, IResponse
    {
        public string RefreshToken { get; set; }
    }
}
