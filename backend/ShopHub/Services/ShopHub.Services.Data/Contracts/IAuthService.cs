namespace ShopHub.Services.Data.Contracts
{
    using ShopHub.Services.Models.Auth;
    using ShopHub.Services.Models.Base;

    public interface IAuthService
    {
        Task<BaseResponse<BaseAuthResponse>> Register(RegisterRequest request);

        Task<BaseResponse<LoginResponse>> Login(LoginRequest request, string ipAddress);

        Task<BaseResponse<RefreshTokenResponse>> RefreshToken(string token);

        Task<BaseResponse> Logout(string token);
    }
}
