using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Models
{
    public class Emp
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set;}
        [Required]
        [EmailAddress(ErrorMessage ="Shi email address bhro--")]
        public string Email { get; set; }

        [Required]
        public decimal Salary { get; set; } = 0;

        [Required]
        public string Department { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }
    }
}
