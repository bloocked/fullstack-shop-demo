using backend.DTOs;

namespace backend.Services.Interfaces
{
    /// <summary>
    /// Defines business logic related to user operations
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticates a user with given username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>A <see cref="UserDto"/> containing user profile data</returns>
        UserDto? Authenticate(string username, string password);
    }
}
