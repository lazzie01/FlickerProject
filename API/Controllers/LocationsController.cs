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
    public class LocationsController : ControllerBase
    {
        private IService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public LocationsController(IService userService, IWebHostEnvironment webHostEnvironment)
        {
            _service = userService;
            _webHostEnvironment = webHostEnvironment;
            string rootPath = Path.GetFullPath(Path.Combine(_webHostEnvironment.ContentRootPath, @"..\"));
            _imagesPath = rootPath + @"Frontend\my-app\src\assets\";
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.Locations(id);
            return Ok(data);
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]SearchModel searchModel)
        {
            searchModel.Id = id;
            _service.AddLocation(searchModel, _imagesPath);
            return Ok();
        }

        [HttpGet("{id}/landmarks")] 
        public IActionResult Landmarks(int id)
        {
            var data = _service.Landmarks(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, int userId)
        {
            _service.DeleteLocation(userId, id);
            return Ok();
        }

    }
}
