using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage ="Name Field is requied")]
        [MaxLength(50 , ErrorMessage ="Mximum Name Length is 50 Characters")]
        [MinLength(2 , ErrorMessage ="Mximum Name Length is 50 Characters")]
        public string Name { get; set; }
        [Range(22,50, ErrorMessage ="The Age Must be between 22 and 50")]
        public int? Age { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
       
        public bool IsActive { get; set; } = true;
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]

        public string PhoneNumber {get; set; }

        [Display(Name ="Hiring Date")]
        public DateTime HiringDate  { get; set; } = DateTime.Now;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } =false;
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [EnumDataType(typeof(EmpType))]
        public EmpType EmpType { get; set; }    


    }
}
