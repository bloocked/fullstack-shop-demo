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

        /// <summary>
        /// Authenticates a user based on the provided credentials and returns the user details if successful.
        /// </summary>
        /// <remarks>This method sends a notification to the user upon successful login.</remarks>
        /// <param name="dto">An object containing the username and password for authentication.</param>
        /// <returns>An <see cref="IActionResult"/> containing the authenticated user details if the login is successful. Returns
        /// <see cref="UnauthorizedObjectResult"/> with an error message if the credentials are invalid.</returns>
        // POST: api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _userService.Authenticate(dto.Username, dto.Password);
            if (user == null)
            {
                return Unauthorized(new { error = "Invalid username or password." });
            }

            var notification = _notificationService.SendNotification(user.Id, "Login successful");

            return Ok(user);
        }

    }
}
