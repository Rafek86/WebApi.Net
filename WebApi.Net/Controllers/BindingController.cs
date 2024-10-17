using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Net.Models;

namespace WebApi.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult TestPrimitive(int age ,string? name) { 
        //return Ok();    
        //}

        [HttpGet("{age:int}/{name:alpha}")]
        public IActionResult TestPrimitive(int age ,string? name) { 
        return Ok();    
        }

        [HttpPost]
        public IActionResult TestObj(Department dept, string? name) {
            return Ok();
        }

        //    public IActionResult TestCustomBind(int id, string name, string managerName) { 

        //    }

        [HttpGet("{id:int}/{name:alpha}/{managerName:alpha}")]
        public IActionResult TestCustomBind([FromRoute]Department dept)
        {
            return Ok();
        }

    
    }
}
