using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcRoute.BLL.Helper;
using MvcRoute.DAL.Models;
using MvcRoute.PL.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcRoute.PL.Controllers
{
    public class AccountController : Controller


    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        public AccountController(IMapper mapper , UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager) {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register(RegisterViewModel registerViewModel) {
            string imagename  =string.Empty;
            if (ModelState.IsValid) {
                var user = mapper.Map<RegisterViewModel, ApplicationUser>(registerViewModel);
                user.PasswordHash = registerViewModel.Password;

                
                if (registerViewModel.Image != null) {
                    try {
                        imagename = FileHandler.UploadFile(registerViewModel.Image, "images");
                        user.Image = imagename;
                    }
                    catch { 
                    }
                }
                var result =  await userManager.CreateAsync(user , user.PasswordHash);
                if (result.Succeeded)
                {
                    await signInManager.SignInWithClaimsAsync(user, false,

                               new List<Claim>(){
                                 new ("image",imagename){ }
                               }
                               );

                    return RedirectToAction("Index", "Home");
                    
                }
                else {
                    FileHandler.DeleteFile(imagename, "images");
                    foreach (var err in result.Errors) {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
        
            return View(registerViewModel);
        
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid) {
                var result = await userManager.FindByNameAsync(loginViewModel.Username);
                if (result != null) {

                  var found =   await userManager.CheckPasswordAsync(result, loginViewModel.Password);
                    if (found) {
                        await signInManager.SignInWithClaimsAsync(result, loginViewModel.RememberMe, 
                            
                            new List<Claim>(){
                            new ("image",result.Image??""){ }
                            }
                            ) ;
                        return RedirectToAction("Index", "Home");
                    
                    }
                }
            
            }

            ModelState.AddModelError("", "Invalid UserName or Password");
            return View(loginViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
    }
}
