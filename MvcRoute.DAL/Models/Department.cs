using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRoute.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Code Is Required")]
        public string Code { get; set; }
        [Display(Name = "Created At")]

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
