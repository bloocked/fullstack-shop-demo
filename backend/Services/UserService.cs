using System.Security.Cryptography.Xml;
using backend.Data;
using backend.DTOs;
using backend.Repos.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
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

            if(user.Password != password) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username
            };
        }
    }
}
