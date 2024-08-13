using Microsoft.AspNetCore.Identity;

namespace MvcRoute.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Image { get; set; }

    }
}
