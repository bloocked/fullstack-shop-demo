using backend.Models;

namespace backend.Repos.Interfaces
{
    /// <summary>
    /// Defines the contract for user data operations
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the first user with given username
        /// </summary>
        /// <param name="username">the username to query for</param>
        /// <returns>The user entity or null if not found</returns>
        User? GetByUsername(string username);
    }
}
