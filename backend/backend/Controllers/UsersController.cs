using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YamSoft_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IConfiguration configuration;
        public UsersController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

    }
}
