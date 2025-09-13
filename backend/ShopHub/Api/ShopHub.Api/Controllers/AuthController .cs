namespace ShopHub.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
 
    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Auth;
    using ShopHub.Services.Models.Base;

    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUsersService usersService;

        public AuthController(IAuthService authService, IUsersService usersService)
        {
            this.authService = authService;
            this.usersService = usersService;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                BaseResponse response = await authService.Register(request);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }

               return BadRequest(response); 
            }
             
            return BadRequest(ModelState);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                BaseResponse<LoginResponse> response = await authService.Login(request, ipAddress);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                    
                return Unauthorized(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPost(nameof(RefreshToken))]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (ModelState.IsValid)
            {
                BaseResponse<RefreshTokenResponse> response = await authService.RefreshToken(request.Token);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }

                return Unauthorized(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPost(nameof(Logout))]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenRequest request)
        {
            if (ModelState.IsValid)
            {
                bool success = await authService.Logout(request.Token);
                if (success)
                {
                    return Ok(success);
                }

                return NotFound();
            }

            return BadRequest(ModelState);
        }
    }
}
