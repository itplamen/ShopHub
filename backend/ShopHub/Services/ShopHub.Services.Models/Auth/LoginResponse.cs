namespace ShopHub.Services.Models.Auth
{
    using ShopHub.Services.Models.Contracts;

    public class LoginResponse : TokenResponse, IResponse
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string RefreshToken { get; set; }
    }
}
