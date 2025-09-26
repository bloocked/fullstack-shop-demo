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

        // POST: api/notifications/send
        [HttpPost("send")]
        public IActionResult SendNotification([FromQuery] string message, [FromQuery] int userId)
        {
            NotificationDto? result = _notificationService.SendNotification(userId, message);
            if (result == null)
            {
                return BadRequest(new { error = "Failed to send notification." });
            }
            return Ok(new { success = "Notification sent successfully." });
        }
    }
}
