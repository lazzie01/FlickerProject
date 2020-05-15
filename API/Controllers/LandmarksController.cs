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
            var data = _service.Landmark(id);
            return Ok(data);
        }

    }
}
