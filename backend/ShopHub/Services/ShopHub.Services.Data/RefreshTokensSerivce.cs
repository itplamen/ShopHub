namespace ShopHub.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
   
    using ShopHub.Data.Contracts;
    using ShopHub.Data.Models;
    using ShopHub.Services.Data.Contracts;

    public class RefreshTokensSerivce : IRefreshTokensSerivce
    {
        private readonly IConfiguration configuration;
        private readonly IRepository<RefreshToken> repository;

        public RefreshTokensSerivce(IConfiguration configuration, IRepository<RefreshToken> repository)
        {
            this.configuration = configuration;
            this.repository = repository;
        }

        public async Task<string> Generate(int userId, string ipAddres, string deviceId, string deviceName)
        {
            var refreshToken = new RefreshToken()
            {
                Token = Guid.NewGuid().ToString(),
                UserId = userId,
                IPAddress = ipAddres,
                DeviceId = deviceId,
                DeviceName = deviceName,
                ExpiryDate = DateTime.UtcNow.AddMinutes(int.Parse(configuration["Jwt:RefreshTokenValidityMins"]))
            };

            await repository.AddAsync(refreshToken);

            return refreshToken.Token;
        }

        public async Task<RefreshToken> Get(string token)
        {
            RefreshToken refreshToken = await repository.Filter()
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == token && x.ExpiryDate > DateTime.UtcNow && x.DeletedOn == null);

            return refreshToken;
        }

        public void Revoke(RefreshToken token) => repository.Delete(token);

        public async Task SaveChanges() => await repository.SaveChangesAsync();
    }
}
