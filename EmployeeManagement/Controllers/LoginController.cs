using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Authentication;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // email n password
            if (model.Email == "admin" && model.Password == "password")
            {
                var employee = new Employee
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = model.Email
                };

                var token = _authService.GenerateJwtToken(employee);

                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }

    public class LoginModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
