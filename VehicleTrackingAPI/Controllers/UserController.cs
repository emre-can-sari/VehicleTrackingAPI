using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Business.Dtos;
using VehicleTracking.Business.Services;

namespace VehicleTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("Username and password are required.");
            }

            _userService.Register(userDto);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto UserDto)
        {
            if (UserDto == null || string.IsNullOrEmpty(UserDto.UserName) || string.IsNullOrEmpty(UserDto.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var userResponse = _userService.Login(UserDto);
            if (userResponse == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(userResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var userDto = _userService.GetUserById(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
