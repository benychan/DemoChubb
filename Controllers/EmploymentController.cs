using Empleados.Models;
using Empleados.Service;
using Microsoft.AspNetCore.Mvc;

namespace Empleados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmploymentController : ControllerBase
    {
        private readonly IEmploymentService service;

        public EmploymentController(IEmploymentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await service.GetEmpleados();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployment(int id)
        {
            var user = await service.GetEmpleado(id); 
            return Ok(user);
        }

        
        [HttpPost]
        public async void CreateEmployment([FromBody] Empleado empleado)
        {
            service.CreateEmpleado(empleado);
            Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployment(int id, [FromBody] Empleado empleado)
        {
            service.UpdateEmpleado(id,  empleado);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult RemoveEmployment(int id)
        {
            service.DeleteEmpleado(id);
            return Ok();
        }
    }
}
