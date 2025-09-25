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
        /// Gets the user with given id
        /// </summary>
        /// <param name="id">the id to query for</param>
        /// <returns>The user entity, or null if not found</returns>
        public User? GetById(int id)
        {
            return _context.Users.Find(id);
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

        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        /// <param name="user">the user to add</param>
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="user">the user to delete</param>
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
