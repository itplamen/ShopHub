namespace ShopHub.Services.Models.Auth
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public int ExpiresIn { get; set; }
    }
}
