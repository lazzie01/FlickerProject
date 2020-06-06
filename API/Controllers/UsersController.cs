using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IService _service;
        public UsersController(IService userService, IWebHostEnvironment webHostEnvironment)
        {
            _service = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel authenticateModel)
        {
            var user = _service.AuthenticateUser(authenticateModel);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserModel userModel)
        {
            if (_service.RegisterUser(userModel))
            {
                return Ok();
            }
            else
            {
                return Conflict(new { message = "Username already taken" });
            }
        }
    }
}
