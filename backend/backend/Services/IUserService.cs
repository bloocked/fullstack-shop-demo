using YamSoft_backend.DTOs;

namespace YamSoft_backend.Services
{
    /// <summary>
    /// Defines business logic related to user operations
    /// </summary>
    public interface IUserService
    {
        UserDto? Authenticate(string username, string password);
    }
}
