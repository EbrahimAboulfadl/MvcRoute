using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcRoute.BLL.Interfaces;
using MvcRoute.DAL.Models;
using MvcRoute.PL.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRoute.PL.Controllers
{
    [Authorize(Roles ="Admin,Manager")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid) {
                IdentityRole role = new IdentityRole() { Name = roleViewModel.RoleName };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded) {
                    TempData["Message"] = "Role Added Successfully";
                return View();
                }
                foreach (var err in result.Errors) ModelState.AddModelError("", err.Description);

            }
   

           return View(roleViewModel);
        }

        [HttpGet]
        public IActionResult Assign() {
            ViewBag.Users = userManager.Users;
  
            ViewBag.Roles = roleManager.Roles;        
        return View();
        }   
        
        [HttpPost]
        public async Task<IActionResult> Assign(AssignRoleViewModel assignRoleViewModel) {

            if (ModelState.IsValid) {

                ApplicationUser user = await userManager.FindByIdAsync(assignRoleViewModel.UserId);

                var result = await userManager.AddToRoleAsync(user, assignRoleViewModel.RoleName);
                if (result.Succeeded) {

                    TempData["Message"] = "Role Assigned To User Successfully";
                    return  RedirectToAction();
                }
                foreach (var err in result.Errors) ModelState.AddModelError("", err.Description);
            }
            ViewBag.Users = userManager.Users;

            ViewBag.Roles = roleManager.Roles;
            return View(assignRoleViewModel);
        }
    }
}
