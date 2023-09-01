using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


using ViopOrtalama.Entities.Enitities;
using ViopOrtalamaHesaplama.UI.FluentValidators.RegisterValidation;
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

        public async Task<IActionResult> Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterVM);
            }

            Random random = new Random();
            int code = random.Next(100000, 1000000);

            AppUser appUser = new AppUser()
            {
                FirstName = userRegisterVM.FirstName,
                LastName = userRegisterVM.LastName,
                Email = userRegisterVM.Email,
                PhoneNumber = userRegisterVM.PhoneNumber,
                Job = userRegisterVM.Job,
                BirthDate = userRegisterVM.BirthDate,
                UserName = userRegisterVM.Email, // Kullanıcı adını e-posta olarak ayarla (opsiyonel)
                ConfirmCode = code,
            };

            var result = await _userManager.CreateAsync(appUser, userRegisterVM.Password);

            if (result.Succeeded)
            {
                // Kullanıcı başarılı bir şekilde oluşturulduysa, başka bir işlem yapabilirsiniz.
                // Örneğin, bir onay e-postası gönderme işlemi gerçekleştirebilirsiniz.

                return RedirectToAction("Login", "Login"); // İşlem başarılıysa, "Home" controller'ının "Index" action'ına yönlendirme yapıyorum.
            }
            else
            {
                // Kullanıcı oluşturma işlemi başarısız olduysa, hata mesajlarını işleme alabilirsiniz.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(userRegisterVM); // Hataları göstermek için tekrar formu döndürüyorum.
            }
        }



    }
}
