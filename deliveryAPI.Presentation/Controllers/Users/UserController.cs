using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using deliveryAPI.Application.Interfaces.Users;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Presentation.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return Ok(createdUser);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, User user)
        {
            var updatedUser = await _userService.UpdateUserAsync(userId, user);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }
    }
}
