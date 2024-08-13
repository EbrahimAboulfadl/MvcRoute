using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvcRoute.DAL.Models
{
   public enum Gender  {
    [EnumMember(Value ="Male")]
    Male = 1,
    [EnumMember(Value ="Female")]
     Female = 2
    }

   public enum EmpType
    {
        [EnumMember(Value = "Fulltime")]
        Fulltime = 1,
        [EnumMember(Value = "Parttime")]
        Parttime = 2

    }

    public class Employee
    {
        public int Id { get; set; }
        [Required()]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(22, 50)]
        public int? Age { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; } = DateTime.Now;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
        public Gender Gender { get; set; }
        public EmpType EmpType { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        //fk optional => onDelete : Restrict
        //fk required => onDelete : Cascade
        [InverseProperty("Employees")]
        public Department Department { get; set; }

        public string Image{get; set;}


    }
}
