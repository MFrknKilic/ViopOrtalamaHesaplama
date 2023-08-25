using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalamaHesaplama.UI.Models.Contracts;
using ViopOrtalamaHesaplama.UI.Models.Users;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index( )
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName=userRegisterVM.FirstName,
                    LastName=userRegisterVM.LastName,
                    Email=userRegisterVM.Email,
                    PhoneNumber=userRegisterVM.PhoneNumber,
                    Password=userRegisterVM.Password,
                    Job=userRegisterVM.Job,
                    BirthDate=userRegisterVM.BirthDate

                };
            }
            return View();
        }
    }
       
    
}
