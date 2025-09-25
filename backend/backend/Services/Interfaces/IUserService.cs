using backend.DTOs;

namespace backend.Services.Interfaces
{
    /// <summary>
    /// Defines business logic related to user operations
    /// </summary>
    public interface IUserService
    {
        UserDto? Authenticate(string username, string password);
    }
}
