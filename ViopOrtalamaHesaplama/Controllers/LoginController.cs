using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Repositories.Abstract;
using ViopOrtalamaHesaplama.UI.Models;
using ViopOrtalamaHesaplama.UI.Models.Users;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    public class LoginController : Controller
    {
       private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
     
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager )
        {
            _userManager = userManager;
           
            _signInManager = signInManager; 
        }
      
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginViewModel)
        {
            var email = loginViewModel.Email.Normalize().ToLower();
            var user = await _userManager.FindByEmailAsync(email);


            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);
            if (result.Succeeded)
            {
                
               

                    return RedirectToAction("CreateContractCompany", "Contract");
                
                //else lütfen mail adresinizi onaylayın
            }
            //kullanıcı adı veya şifre hatalı
            return View();
        }
      }
}



