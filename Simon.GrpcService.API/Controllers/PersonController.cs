using Microsoft.AspNetCore.Mvc;
using Simon.GrpcService.API;
using Simon.GrpcService.GrpcService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Acsdsoc.GrpcService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonInfoService _personInfoService;

        public PersonController(PersonInfoService personInfoService)
        {
            _personInfoService = personInfoService;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public JsonResult Get()
        {
            var list = _personInfoService.GetAll(null, null);

            return new JsonResult(list);
        }

        // GET api/<PersonController>/5   http://localhost:55114/api/Person/2
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var reqUserId = new RequestUserId
            {
                Id = id
            };
            var person = _personInfoService.GetPersonInfoById(reqUserId, null);

            return new JsonResult(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public JsonResult GetPersonInfo()
        {
            var list = _personInfoService.GetAll(null, null);

            return new JsonResult(list.Result.Person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}