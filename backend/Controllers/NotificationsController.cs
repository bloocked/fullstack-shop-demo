using backend.DTOs;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        public readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/notifications/latest?userId=1
        [HttpGet("latest")]
        public IActionResult GetLatestNotification([FromQuery] int userId)
        {
            NotificationDto? result = _notificationService.GetLatestForUser(userId);
            if (result == null)
            {
                return NotFound(new { error = "No notifications found for the user." });
            }
            return Ok(result);
        }
    }
}
