using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViopOrtalama.Business.Abstract;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalamaHesaplama.UI.Models;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    public class ContractController : BaseController
    {

        private readonly IGenericService<Contract> _contractService;


        public ContractController(UserManager<AppUser> userManager, IGenericService<Contract> contractService):base(userManager)
        {
            _contractService = contractService;

        }

        [HttpGet]
        public async Task<IActionResult> CreateContractCompany()
        {
            var currentUser = await GetCurrentUserAsync();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContractCompany(ContractVM vm)
        {
            var vam = vm;
            var currentUser = await GetCurrentUserAsync();


            return View();

        }
        [HttpGet]
        public async Task<IActionResult> CreateContractCommodity()
        {
            var currentUser = await GetCurrentUserAsync();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContractCommodity(ContractVM vm)
        {
            var vam = vm;
            var currentUser = await GetCurrentUserAsync();


            return View();

        }
        [HttpGet]
        public async Task<IActionResult> CreateContractCurrency()
        {
            var currentUser = await GetCurrentUserAsync();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContractCurrency(ContractVM vm)
        {
            var vam = vm;
            var currentUser = await GetCurrentUserAsync();


            return View();

        }
        [HttpGet]
        public async Task<IActionResult> CreateContractAvarage()
        {
            var currentUser = await GetCurrentUserAsync();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContractAvarage(ContractVM vm)
        {
            var vam = vm;
            var currentUser = await GetCurrentUserAsync();


            return View();

        }

        //    public async Task<IActionResult> OpenContract()
        //    {
        //        AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

        //        return View();
        //    }
        //    public async Task<IActionResult> MyArticleListForEdit()//tüm Contratlarımı görüntülediğim sayfa
        //    {
        //        AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);//login olan kullanıcı(author)


        //        return View(articles);
        //    }
        //    public async Task<IActionResult> ArticleDetails(int id)//makale detaylarım
        //    {
        //        AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
        //        Article article = _articleService.GetById(id);
        //        if (currentUser.Id == article.AuthorId)
        //        {
        //            return View(article);

        //        }
        //        return RedirectToAction("MyArticleListForEdit");
        //    }
        //
    }
}
