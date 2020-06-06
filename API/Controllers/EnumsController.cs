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
    public class EnumsController : ControllerBase
    {
        private EnumService enumService;

        public EnumsController()
        {
            enumService = new EnumService();
        }

        [HttpPost("{id}")]
        public IActionResult Create(string id,[FromBody]EnumModel model)
        {
            var enumVar = model.ToModel();
            switch (id)
            {
                case "organization": { 
                                      enumService.Create(new Enum_Organization(enumVar)); break; 
                                     }
                case "department":
                    {
                        enumService.Create(new Enum_Department(enumVar)); break;
                    }
                case "role":
                    {
                        enumService.Create(new Enum_Role(enumVar)); break;
                    }
                case "id-type":
                    {
                        enumService.Create(new Enum_IdType(enumVar)); break;
                    }
                case "province":
                    {
                        enumService.Create(new Enum_Province(enumVar)); break;
                    }
                case "country":
                    {
                        enumService.Create(new Enum_Country(enumVar)); break;
                    }
                case "port-of-entry":
                    {
                        enumService.Create(new Enum_PortOfEntry(enumVar)); break;
                    }
                case "covid-status":
                    {
                        enumService.Create(new Enum_CovidStatus(enumVar)); break;
                    }
                case "hiv-status":
                    {
                        enumService.Create(new Enum_HIVStatus(enumVar)); break;
                    }
                case "patient-status":
                    {
                        enumService.Create(new Enum_PatientStatus(enumVar)); break;
                    }
                case "sex":
                    {
                        enumService.Create(new Enum_Sex(enumVar)); break;
                    }
                case "town":
                    {
                        enumService.Create(new Enum_Town(enumVar)); break;
                    }
                default: { break; }
            }

            return Ok();
            //if (user == null)
            //    return BadRequest(new { message = "Username or password is incorrect" });

        }

        [HttpGet("{id}/{key}")]
        public IActionResult Read(string id, int key)
        {
            DataLayer.Enum data = null;

            switch (id)
            {
                case "organization":
                    {
                        data = enumService.Read(typeof(Enum_Organization),key); break;
                    }
                case "department":
                    {
                        data = enumService.Read(typeof(Enum_Department), key); break;
                    }
                case "role":
                    {
                        data = enumService.Read(typeof(Enum_Role), key); break;
                    }
                case "id-type":
                    {
                        data = enumService.Read(typeof(Enum_IdType), key); break;
                    }
                case "province":
                    {
                        data = enumService.Read(typeof(Enum_Province), key); break;
                    }
                case "country":
                    {
                        data = enumService.Read(typeof(Enum_Country), key); break;
                    }
                case "port-of-entry":
                    {
                        data = enumService.Read(typeof(Enum_PortOfEntry), key); break;
                    }
                case "covid-status":
                    {
                        data = enumService.Read(typeof(Enum_CovidStatus), key); break;
                    }
                case "hiv-status":
                    {
                        data = enumService.Read(typeof(Enum_HIVStatus), key); break;
                    }
                case "patient-status":
                    {
                        data = enumService.Read(typeof(Enum_PatientStatus), key); break;
                    }
                case "sex":
                    {
                        data = enumService.Read(typeof(Enum_Sex), key); break;
                    }
                case "town":
                    {
                        data = enumService.Read(typeof(Enum_Town), key); break;
                    }
                default: { break; }

            }

            return Ok(data);
        }

        [HttpPut("{id}/{key}")]// host/enum/organization/1
        public IActionResult Update(string id, int key, [FromBody]EnumModel model)
        {
            DataLayer.Enum data = model.ToModel();

            switch (id)
            {
                case "organization":
                    {
                       enumService.Edit(typeof(Enum_Organization), key, data); break;
                    }
                case "department":
                    {
                       enumService.Edit(typeof(Enum_Department), key, data); break;
                    }
                case "role":
                    {
                        enumService.Edit(typeof(Enum_Role), key, data); break;
                    }
                case "id-type":
                    {
                        enumService.Edit(typeof(Enum_IdType), key, data); break;
                    }
                case "province":
                    {
                        enumService.Edit(typeof(Enum_Province), key, data); break;
                    }
                case "country":
                    {
                        enumService.Edit(typeof(Enum_Country), key, data); break;
                    }
                case "port-of-entry":
                    {
                        enumService.Edit(typeof(Enum_PortOfEntry), key, data); break;
                    }
                case "covid-status":
                    {
                        enumService.Edit(typeof(Enum_CovidStatus), key, data); break;
                    }
                case "hiv-status":
                    {
                        enumService.Edit(typeof(Enum_HIVStatus), key, data); break;
                    }
                case "patient-status":
                    {
                        enumService.Edit(typeof(Enum_PatientStatus), key, data); break;
                    }
                case "sex":
                    {
                        enumService.Edit(typeof(Enum_Sex), key, data); break;
                    }
                case "town":
                    {
                        enumService.Edit(typeof(Enum_Town), key, data); break;
                    }
                default: { break; }

            }

            return Ok();
        }

        [HttpDelete("{id}/{key}")]// host/enum/organization/1
        public IActionResult Delete(string id, int key)
        {
            switch (id)
            {
                case "organization":
                    {
                        enumService.Delete(typeof(Enum_Organization), key); break;
                    }
                case "department":
                    {
                        enumService.Delete(typeof(Enum_Department), key); break;
                    }
                case "role":
                    {
                        enumService.Delete(typeof(Enum_Role), key); break;
                    }
                case "id-type":
                    {
                        enumService.Delete(typeof(Enum_IdType), key); break;
                    }
                case "province":
                    {
                        enumService.Delete(typeof(Enum_Province), key); break;
                    }
                case "country":
                    {
                        enumService.Delete(typeof(Enum_Country), key); break;
                    }
                case "port-of-entry":
                    {
                        enumService.Delete(typeof(Enum_PortOfEntry), key); break;
                    }
                case "covid-status":
                    {
                        enumService.Delete(typeof(Enum_CovidStatus), key); break;
                    }
                case "hiv-status":
                    {
                        enumService.Delete(typeof(Enum_HIVStatus), key); break;
                    }
                case "patient-status":
                    {
                        enumService.Delete(typeof(Enum_PatientStatus), key); break;
                    }
                case "sex":
                    {
                        enumService.Delete(typeof(Enum_Sex), key); break;
                    }
                case "town":
                    {
                        enumService.Delete(typeof(Enum_Town), key); break;
                    }
                default: { break; }

            }

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult List(string id)
        {
            System.Object data = null;

            switch (id)
            {
                case "organization":
                    {
                        data = enumService.List(typeof(Enum_Organization)); break;
                    }
                case "department":
                    {
                        data = enumService.List(typeof(Enum_Department)); break;
                    }
                case "role":
                    {
                        data = enumService.List(typeof(Enum_Role)); break;
                    }
                case "id-type":
                    {
                        data = enumService.List(typeof(Enum_IdType)); break;
                    }
                case "province":
                    {
                        data = enumService.List(typeof(Enum_Province)); break;
                    }
                case "country":
                    {
                        data = enumService.List(typeof(Enum_Country)); break;
                    }
                case "port-of-entry":
                    {
                        data = enumService.List(typeof(Enum_PortOfEntry)); break;
                    }
                case "covid-status":
                    {
                        data = enumService.List(typeof(Enum_CovidStatus)); break;
                    }
                case "hiv-status":
                    {
                        data = enumService.List(typeof(Enum_HIVStatus)); break;
                    }
                case "patient-status":
                    {
                        data = enumService.List(typeof(Enum_PatientStatus)); break;
                    }
                case "sex":
                    {
                        data = enumService.List(typeof(Enum_Sex)); break;
                    }
                case "town":
                    {
                        data = enumService.List(typeof(Enum_Town)); break;
                    }
                default: { break; }
            }
            
            return Ok(data);
        }

       
    }
}
