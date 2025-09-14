namespace ShopHub.Services.Models.Auth
{
    using ShopHub.Services.Models.Contracts;

    public class BaseAuthResponse : IResponse
    {
        public int UserId { get; set; }
    }
}
