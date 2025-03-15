using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }

   
        public required string FirstName { get; set; }


        public required string LastName { get; set; }


        public required string Email { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string Position { get; set; } = String.Empty;


        public decimal Salary { get; set; }
    }
}
