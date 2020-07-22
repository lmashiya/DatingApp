using System.Threading.Tasks;
using DatingApp.API.Interfaces;
using DatingApp.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo ;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();

            if (await _repo.UserExists(username))
            {
                return BadRequest("Username already exists");
            }

            var UserToCreate = new User {
                Username = username
            };

            var createdUser = _repo.Register(UserToCreate,password);

            return StatusCode(201);
        }
    }
}