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

        /// <summary>
        /// Gets the latest notification for a user
        /// </summary>
        /// <param name="userId">the user to get notification for</param>
        /// <returns>Ok if notification is found, NotFound otherwise</returns>
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
