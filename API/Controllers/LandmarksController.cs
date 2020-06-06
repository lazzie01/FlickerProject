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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
        public LandmarksController(IService userService, IWebHostEnvironment webHostEnvironment)
        {
            _service = userService;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = _webHostEnvironment.ContentRootPath + @"\Images\";
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.GetLandmark(id, _imagesPath);
            return Ok(data);
        }

    }
}
