using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProfitLibrary.Api.Models;
using NonProfitLibrary.Api.Models.Services;
using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly EmployeeService _employeeService;

        public EmployeeController(ApplicationContext db)
        {
            _db = db;
            _employeeService = new EmployeeService(db);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeModel>> GetEmployee()
        {
            return await _db.Employee.Select(u => u.ToDto()).ToListAsync();
        }
        [HttpGet("{id}")]
        public ActionResult<EmployeeModel> GetUser(int id)
        {
            var user = _employeeService.Get(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeeModel employeeModel)
        {
            if(employeeModel != null)
            {
                var result = _employeeService.Create(employeeModel);
                return result ? Ok(result) : NoContent();
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeModel employeeModel)
        {
            if(employeeModel != null) 
            {
                bool result = _employeeService.Update(id, employeeModel);
                return result ? Ok(result) : NoContent();
            }
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _employeeService.Delete(id);
            return result ? Ok(result) : NoContent();
        }
        
    }
}
