using API.Models;
using API.Services;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestCentresController : ControllerBase
    {
        private TestCentreService testCentreService;

        public TestCentresController()
        {
            testCentreService = new TestCentreService();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody]TestCentreModel model)
        {
            testCentreService.Create(model.ToModel());
            return Ok();
           
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var data = testCentreService.Read(id);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]TestCentreModel model)
        {
            
            testCentreService.Edit(id, model.ToModel());
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            testCentreService.Delete(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult List()
        {
            return Ok(testCentreService.List());
        }
    }
}
