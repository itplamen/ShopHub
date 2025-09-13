namespace ShopHub.Services.Data.Contracts
{
    using ShopHub.Services.Models.User;

    public interface IUsersService
    {
        Task<UserResponse> GetById(int id);
    }
}
