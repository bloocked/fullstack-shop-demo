using backend.Models;

namespace backend.Repos.Interfaces
{
    /// <summary>
    /// Defines the contract for user data operations
    /// </summary>
    public interface IUserRepository
    {
        User? GetByUsername(string username);
    }
}
