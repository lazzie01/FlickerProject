using API.Models;
using API.Services;
using API.ViewModels;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private PatientCentreService patientCentreService;
        private UserService userService;
        public PatientController()
        {
            patientCentreService = new PatientCentreService();
            userService = new UserService();
        }

        [Authorize(Roles = "capturer")]
        [HttpPost]
        public IActionResult Create([FromBody]PatientModel model)
        {
            var currentUser = userService.Read(int.Parse(User.Identity.Name));
            var entity = model.ToModel();
            entity.CapturerId = currentUser.Id;
            entity.CaptureDate = System.DateTime.Now;
            entity.TestCentreId = currentUser.TestCentreId;
            patientCentreService.Create(entity);
            return Ok();    
        }

        [Authorize(Roles = "capturer")]
        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var currentUser = userService.Read(int.Parse(User.Identity.Name));
            var data = patientCentreService.Read(id, currentUser.TestCentreId.GetValueOrDefault(0));
            var viewModel = new PatientVM(data);
            return Ok(viewModel);
        }

        [Authorize(Roles = "capturer")]
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]PatientModel model)
        {
            var currentUser = userService.Read(int.Parse(User.Identity.Name));
            patientCentreService.Edit(id, model.ToModel(), currentUser.TestCentreId.GetValueOrDefault(0));
            return Ok();
        }

        [Authorize(Roles = "capturer")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentUser = userService.Read(int.Parse(User.Identity.Name));
            patientCentreService.Delete(id, currentUser.TestCentreId.GetValueOrDefault(0));
            return Ok();
        }

        [Authorize(Roles = "capturer")]
        [HttpGet]
        public IActionResult List()
        {
            var currentUser = userService.Read(int.Parse(User.Identity.Name));
            var data = patientCentreService.List(currentUser.TestCentreId.GetValueOrDefault(0));
            var viewModel = data.Select(d => new PatientListVM(d));
            return Ok(viewModel);
        }
    }
}
