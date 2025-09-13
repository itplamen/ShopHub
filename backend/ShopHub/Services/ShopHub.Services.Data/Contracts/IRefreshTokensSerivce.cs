namespace ShopHub.Services.Data.Contracts
{
    using ShopHub.Data.Models;

    public interface IRefreshTokensSerivce
    {
        Task<string> Generate(int userId, string ipAddres, string deviceId, string deviceName);

        Task<RefreshToken> Get(string token);

        void Revoke(RefreshToken token);

        Task SaveChanges();
    }
}
