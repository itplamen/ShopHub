namespace ShopHub.Api.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Base;
    using ShopHub.Services.Models.Notification;

    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            this.notificationsService = notificationsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            BaseResponse<NotificationResponse> response = await notificationsService.Get(userId);

            if (response.IsSuccess)
            {
                await notificationsService.MarkAsRead(response.Data.Id);
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
