using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "this is required")]

        [Required(ErrorMessage = "this is required")]
        public string Name { get; set; } = "temp";
        [Required(ErrorMessage = "this is required")]
        public string Position { get; set; }
        [Required(ErrorMessage = "this is required")]
        public DateOnly DateOfBirth { get; set; }
        [Required(ErrorMessage = "this is required")]
        [EmailAddress(ErrorMessage = "Shi email address bhro--")]
        public string Email { get; set; }
        public decimal Salary { get; set; } = 0;

        [Required(ErrorMessage = "this is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "this is required")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "this is required")]
        public DateOnly JoiningDate { get; set; }
    }
}
