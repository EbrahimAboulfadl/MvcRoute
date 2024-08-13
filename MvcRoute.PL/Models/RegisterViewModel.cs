using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MvcRoute.PL.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        [Required]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 

        public IFormFile Image { get; set; }


    }
}
