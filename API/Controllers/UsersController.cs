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
        private UserService userService;

        public UsersController()
        {
            userService = new UserService();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel authenticateModel)
        {
            var user = userService.Authenticate(authenticateModel);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);

        }

        [Authorize(Roles = "super_admin")]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserModel userModel)
        {
            if (userService.Create(userModel))
            {
                return Ok();
            }
            else
            {
                return Conflict(new { message = "Username already taken" });
            }
        }

        [Authorize(Roles = "super_admin")]
        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var data = userService.Read(id);
            UserModel userModel = new UserModel(data);
            return Ok(userModel);
        }

        [Authorize(Roles = "super_admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserModel model)
        {

            userService.Edit(id, model.ToModel());
            return Ok();
        }

        [Authorize(Roles = "super_admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return Ok();
        }

        [Authorize(Roles = "super_admin")]
        [HttpGet]
        public IActionResult List()
        {
            return Ok(userService.List());
        }
    }
}
