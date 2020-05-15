using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LandmarksController : ControllerBase
    {
        private IService _service;
      
        public LandmarksController(IService userService, IWebHostEnvironment webHostEnvironment)
        {
            _service = userService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.GetLandmark(id);
            return Ok(data);
        }

    }
}
