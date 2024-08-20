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
        private UserService userService;
        private JwtService jwtService;
        public UserController(UserService _userService, JwtService _jwtService)
        {
            userService = _userService;
            jwtService = _jwtService;
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

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> login([FromBody] UserModel user)
        {
            UserModel userFromDb = await userService.getUserByUserNameAndPassword(user.userName, user.UNHASHEDPassword);
            if (userFromDb == null)
            {
                return Unauthorized("Invalid user name or password");
            }
            string token = jwtService.genJWToken(userFromDb);
            return Ok(token);
        }
    }
}
