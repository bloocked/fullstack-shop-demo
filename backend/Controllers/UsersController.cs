using backend.DTOs;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public readonly INotificationService _notificationService;
        public UsersController(IUserService userService, INotificationService notificationService)
        {
            _userService = userService;
            _notificationService = notificationService;
        }

        // POST: api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _userService.Authenticate(dto.Username, dto.Password);
            if (user == null)
            {
                return Unauthorized(new { error = "Invalid username or password." });
            }

            NotificationDto? notification = _notificationService.SendNotification(user.Id, "Login successful");

            return Ok(user);
        }

    }
}
