namespace ShopHub.Services.Data
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using AutoMapper;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    
    using ShopHub.Data.Models;
    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Auth;
    using ShopHub.Services.Models.Base;

    public class AuthService : IAuthService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly IRefreshTokensSerivce refreshTokensSerivce;

        public AuthService(IMapper mapper, IConfiguration configuration, UserManager<User> userManager, IRefreshTokensSerivce refreshTokensSerivce)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.userManager = userManager;
            this.refreshTokensSerivce = refreshTokensSerivce;
        }

        public async Task<BaseResponse> Register(RegisterRequest request)
        {
            User user = await userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                User newUser = mapper.Map<User>(request);
                IdentityResult result = await userManager.CreateAsync(newUser, request.Password);
                var response = mapper.Map<BaseResponse>(result);

                return response;
            }

            return new BaseResponse("Username already exists");
        }

        public async Task<BaseResponse<LoginResponse>> Login(LoginRequest request, string ipAddress)
        {
            User user = await userManager.FindByNameAsync(request.UserName);

            if (user != null)
            {
                bool isValid = await userManager.CheckPasswordAsync(user, request.Password);

                if (isValid)
                {
                    TokenResponse jwtToken = GenerateJwtToken(user);
                    string refreshToken = await refreshTokensSerivce.Generate(user.Id, ipAddress, request.DeviceId, request.DeviceName);

                    return new BaseResponse<LoginResponse>()
                    {
                        Data = new LoginResponse()
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            FullName = user.FullName,
                            Token = jwtToken.Token,
                            ExpiresIn = jwtToken.ExpiresIn,
                            RefreshToken = refreshToken
                        }
                    };
                }

                return new BaseResponse<LoginResponse>("Invalid password");
            }

            return new BaseResponse<LoginResponse>("Username does not exists");
        }

        public async Task<BaseResponse<RefreshTokenResponse>> RefreshToken(string token)
        {
            RefreshToken refreshToken = await refreshTokensSerivce.Get(token);

            if (refreshToken != null)
            {
                refreshTokensSerivce.Revoke(refreshToken);

                TokenResponse newToken = GenerateJwtToken(refreshToken.User);

                string newRefreshToken = await refreshTokensSerivce.Generate(refreshToken.User.Id, refreshToken.IPAddress, refreshToken.DeviceId, refreshToken.DeviceName);
                await refreshTokensSerivce.SaveChanges();

                return new BaseResponse<RefreshTokenResponse>()
                {
                    Data = new RefreshTokenResponse
                    {
                        Token = newToken.Token,
                        ExpiresIn = newToken.ExpiresIn,
                        RefreshToken = newRefreshToken
                    }
                };
            }

            return new BaseResponse<RefreshTokenResponse>("Refresh token does not exist");
        }

        public async Task<bool> Logout(string token)
        {
            RefreshToken refreshToken = await refreshTokensSerivce.Get(token);

            if (refreshToken != null)
            {
                refreshTokensSerivce.Revoke(refreshToken);
                await refreshTokensSerivce.SaveChanges();

                return true;
            }

            return false;
        }

        private TokenResponse GenerateJwtToken(User user)
        {
            DateTime expiration = DateTime.UtcNow.AddMinutes(int.Parse(configuration["Jwt:TokenValidityMins"]));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new []
            {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new TokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = (int)expiration.Subtract(DateTime.UtcNow).TotalSeconds
            };
        }
    }
}
