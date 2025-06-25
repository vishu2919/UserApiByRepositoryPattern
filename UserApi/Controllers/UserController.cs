using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Repositories;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
                return NotFound($"User with ID {userId} not found.");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Email))
            {
                return BadRequest("Invalid user data.");
            }

            var createdUser = _userRepository.AddUser(user);
            return Ok(createdUser);
        }
    }
}
