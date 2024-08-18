using Linkdout.Dal;
using Linkdout.DTO;
using Linkdout.Moodels;
using Linkdout.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Linkdout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService _userService)
        {
            userService = _userService;

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SingleUserResponseDTO>> getUser(int id)
        {
            UserModel user = await userService.getUserById(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> register([FromBody] UserModel user)
        {
            int userId = await userService.register(user);
            if (userId != 0)
            {
                return Ok(userId);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
