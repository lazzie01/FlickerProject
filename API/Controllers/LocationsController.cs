using System.IO;
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
    public class LocationsController : ControllerBase
    {
        private IService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public LocationsController(IService userService, IWebHostEnvironment webHostEnvironment)
        {
            _service = userService;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = _webHostEnvironment.ContentRootPath+@"\Images\";
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.GetLocations(id);
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
            var data = _service.GetLocationLandmarks(id, _imagesPath);
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
