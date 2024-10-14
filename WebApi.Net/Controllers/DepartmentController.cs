using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Net.Models;
using WebApi.Net.Repositories;

namespace WebApi.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        { 
        _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult DisplayAllDept()
        {
          return Ok(_departmentRepository.DisplayAll());
        }

        [HttpGet]
        [Route("{id:int}")]//api/department/id
        public IActionResult GetById(int id) { 
        return Ok(_departmentRepository.GetById(id));
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name) 
        { 
            Department dept =_departmentRepository.GetByName(name);
            return Ok(dept);
        }
        
        [HttpPost]
        public IActionResult AddDept(Department dept) { 
            _departmentRepository.AddDept(dept);
            _departmentRepository.Save();
            //return Created($"http://localhost:5073/api/department/{dept.Id}",dept);
            return CreatedAtAction("GetById",new { id =dept.Id }, dept);
        }

        //api/Dpartment
        [HttpPut("{id:int}")]
        public IActionResult UpdateDept(int id ,Department deptold)
        {
                Department dept=_departmentRepository.GetById(id);
            if (deptold != null)
            {
                dept.Name = deptold.Name;
                dept.ManagerName = deptold.ManagerName;
                _departmentRepository.Save();
                return NoContent();
            }
            else { 
            return NotFound();
            }
        }

    }
}
