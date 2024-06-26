using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("/register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody] UserRequestDto user)
        {
            try
            {
                _userService.Register(user);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<string> Login([FromBody] LoginRequestDto login)
        {
            try
            {
                string token = _userService.Login(login);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<List<UserResponseDto>> GetAll()
        {
            return Ok(_userService.GetAll());
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Update([FromRoute] int id, [FromBody] UserRequestDto user)
        {
            try
            {
                _userService.Update(id, user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
