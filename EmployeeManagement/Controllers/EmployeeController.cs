using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.Services;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // get all 
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return employees.Any() ? Ok(employees) : NoContent();
        }

        // get employee 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Employee ID");

            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return employee != null ? Ok(employee) : NotFound("Employee not found");
        }

        // create
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            var createdEmployee = await _employeeService.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
        }

        // updat
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id <= 0 || employee == null)
                return BadRequest("Invalid data");

            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employee);
            return updatedEmployee != null ? Ok(updatedEmployee) : NotFound("Employee not found");
        }

        // delete
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Employee ID");

            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            return deleted ? NoContent() : NotFound("Employee not found");
        }



    }
}
