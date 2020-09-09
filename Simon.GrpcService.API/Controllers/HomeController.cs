using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Simon.GrpcService.GrpcService;
using Simon.GrpcService.GrpcService.Services;

namespace Simon.GrpcService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly PersonInfoService _personService;

        public HomeController(PersonInfoService personService)
        {
            _personService = personService;
        }

        [HttpGet(template: "Get")]
        public JsonResult Get(int id)
        {
            RequestUserId req = new RequestUserId { Id = id };
            var person = _personService.GetPersonInfoById(req, null);

            //string outStr = JsonConvert.SerializeObject(person);

            return new JsonResult(person);
        }
    }
}