namespace ShopHub.Services.Models.User
{
    using ShopHub.Services.Models.Contracts;

    public class UserResponse : IResponse
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }
    }
}
