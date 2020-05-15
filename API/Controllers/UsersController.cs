using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            var user = _service.Authenticate(authenticateModel);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserModel userModel)
        {
            if (_service.Register(userModel))
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
