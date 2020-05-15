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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public UsersController(IService userService, IWebHostEnvironment webHostEnvironment)
        {
            _service = userService;
            _webHostEnvironment = webHostEnvironment;     
            string rootPath = Path.GetFullPath(Path.Combine(_webHostEnvironment.ContentRootPath, @"..\"));
            _imagesPath = rootPath + @"Frontend\my-app\src\assets\";
            
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

        [HttpGet("{id}/locations")]
        public IActionResult Locations(int id)
        {
            var data =_service.Locations(id);
            return Ok(data);
        }

        [HttpPost("{id}/locations")]
        public IActionResult Locations(int id,[FromBody]SearchModel searchModel)
        {
            //string webRootPath = _webHostEnvironment.WebRootPath;
            searchModel.Id = id;
            _service.AddLocation(searchModel, _imagesPath);
            return Ok();
        }

       // [AllowAnonymous]
        [HttpGet("location-landmarks/{id}")]//landmarks of specific location 
        public IActionResult Landmarks(int id)
        {         
            var data = _service.Landmarks(id);
            return Ok(data);
        }

        //[AllowAnonymous]
        [HttpGet("landmarks/{id}")]//one landmark
        public IActionResult Landmark(int id)
        {
            var data = _service.Landmark(id);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpDelete("delete/{locationId}")]
        public IActionResult Delete(int locationId,int userId)
        {
            _service.DeleteLocation(userId, locationId);
            return Ok();
        }

    }
}
