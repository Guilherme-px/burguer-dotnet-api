using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using burguerAPI.Application.Interfaces;
using burguerAPI.Domain.Entities;

namespace burguerAPI.Presentation.Controllers
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
    }
}
