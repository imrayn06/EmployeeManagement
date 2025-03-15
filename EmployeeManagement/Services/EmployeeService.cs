using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToArrayAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Email = employee.Email;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.Position = employee.Position;
                existingEmployee.Salary = employee.Salary;

                await _context.SaveChangesAsync();
                return existingEmployee;
            }

            return null;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;  
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;  
        }

        Task IEmployeeService.DeleteEmployeeAsync(int id)
        {
            return DeleteEmployeeAsync(id);
        }
    }
}
