using MvcRoute.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace MvcRoute.PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Field is requied")]
        [MaxLength(50, ErrorMessage = "Mximum Name Length is 50 Characters")]
        [MinLength(2, ErrorMessage = "Mximum Name Length is 50 Characters")]
        public string Name { get; set; }
        [Range(22, 50, ErrorMessage = "The Age Must be between 22 and 50")]
        public int? Age { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [EnumDataType(typeof(EmpType))]
        public EmpType EmpType { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        //fk optional => onDelete : Restrict
        //fk required => onDelete : Cascade
        [InverseProperty("Employees")]
        public Department Department { get; set; }

    }
}
