using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Net.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string? Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [ValidateNever]//For binding 
        //or making Department nullable if you want the relationship optional
        public Department? Department { get; set; }
    }
}
