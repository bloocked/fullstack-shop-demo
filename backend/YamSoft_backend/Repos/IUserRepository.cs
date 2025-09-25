using YamSoft_backend.Models;

namespace YamSoft_backend.Repos
{
    /// <summary>
    /// Defines the contract for user data operations
    /// </summary>
    public interface IUserRepository
    {
        User? GetById(int id);
        User? GetByUsername(string username);
        void Add(User user);
        void Delete(User user);
    }
}
