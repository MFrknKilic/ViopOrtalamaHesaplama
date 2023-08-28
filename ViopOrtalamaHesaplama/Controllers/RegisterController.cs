using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

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

        public async Task<IActionResult> Register()
        {
        
        return View();
                }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);

                AppUser appUser = new AppUser()
                {
                    FirstName = userRegisterVM.FirstName,
                    SecondName = userRegisterVM.SecondName,
                    SecondLastName = userRegisterVM.SecondLastName,
                    LastName = userRegisterVM.LastName,
                    Email = userRegisterVM.Email,
                    PhoneNumber = userRegisterVM.PhoneNumber,
                    Job = userRegisterVM.Job,
                    BirthDate = userRegisterVM.BirthDate,
                    Password = userRegisterVM.Password,
                    UserName = Guid.NewGuid().ToString(),
                    ConfirmCode = code,
                  
            };

                var result = await _userManager.CreateAsync(appUser, userRegisterVM.Password);
                if (result.Succeeded)
                {
                    //MimeMessage mimeMessage = new MimeMessage();
                    //MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "projekursapi@gmail.com");
                    //MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    //mimeMessage.From.Add(mailboxAddressFrom);
                    //mimeMessage.To.Add(mailboxAddressTo);

                    //var bodyBuilder = new BodyBuilder();
                    //bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
                    //mimeMessage.Body = bodyBuilder.ToMessageBody();

                    //mimeMessage.Subject = "Easy Cash Onay Kodu";

                    //SmtpClient client = new SmtpClient();
                    //client.Connect("smtp.gmail.com", 587, false);
                    //client.Authenticate("projekursapi@gmail.com", "btfcoirevejxphfr");
                    //client.Send(mimeMessage);
                    //client.Disconnect(true);

                    //TempData["Mail"] = appUserRegisterDto.Email;

                    //return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        if (error.Code == "InvalidEmail")
                        {
                            // Geçersiz e-posta adresi hatası, kullanıcıya bilgi verilebilir
                            ModelState.AddModelError("Email", "Geçerli bir e-posta adresi sağlayın.");
                        }
                        // Diğer hata durumları için gerekirse ek işlemler yapabilirsiniz.
                    }
                    // Hata durumunda işlemi nasıl yöneteceğinizi belirleyin.
                }
            
            }

        

            return View();
        }
    }
       
    
}
