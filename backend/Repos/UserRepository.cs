using backend.Data;
using backend.Models;
using backend.Repos.Interfaces;

namespace backend.Repos
{
    /// <summary>
    /// Implements the user repository for data operations
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the first user with given username
        /// </summary>
        /// <param name="username">the username to query for</param>
        /// <returns>The user entity or null if not found</returns>
        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
