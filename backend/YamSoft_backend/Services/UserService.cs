using System.Security.Cryptography.Xml;
using YamSoft_backend.Data;
using YamSoft_backend.DTOs;
using YamSoft_backend.Repos;

namespace YamSoft_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public UserDto? Authenticate(string username, string password)
        {
           var user = _repo.GetByUsername(username);
            if(user == null) return null;

            var mockHashedPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
            if(user.PasswordHash != mockHashedPassword) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username
            };
        }
    }
}
