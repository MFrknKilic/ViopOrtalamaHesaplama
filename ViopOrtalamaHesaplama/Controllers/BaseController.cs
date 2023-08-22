using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ViopOrtalama.Business.Abstract;
using ViopOrtalama.Entities.Enitities;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
      

        public BaseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
           
        }

        // Async olarak tanımlanan bir Task<AppUser> property'si
        protected async Task<AppUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        // BaseController'ı inherit eden diğer controllerlarda, CurrentUser'ı kullanabilirsiniz.
    }
}

