using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViopOrtalama.Business.Abstract;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalamaHesaplama.UI.Models.Contracts;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    public class ContractController : Controller
    {

        private readonly IGenericService<Contract> _contractService;
        private readonly UserManager<AppUser> _userManager;

        public ContractController(UserManager<AppUser> userManager, IGenericService<Contract> contractService)
        {
            _contractService = contractService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateContractCompany()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContractCompany(ContractCompanyVM ccvm)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            Contract contract = new Contract();

            contract.AppUser = currentUser;
            contract.Quantity = ccvm.Quantity;
            contract.Price = ccvm.Price;
            contract.Company = ccvm.Company;
            contract.Expiry = ccvm.Expiry;
            contract.Position = ccvm.SelectedPosition;

            _contractService.Add(contract);

            return View();

        }

        /**/
        [HttpGet]
        public async Task<IActionResult> CreateContractCommodity()
        {
           


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContractCommodity(CreateContractCommodityVM cccvm)
        {
            var vam = cccvm;
           


            return View();

        }
        /**/
        [HttpGet]
        public async Task<IActionResult> CreateContractCurrency()
        {
           


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContractCurrency(CreateContractCurrencyVM cccurencyvm)
        {
            var vam = cccurencyvm;
            


            return View();

        }

        [HttpGet]
        public async Task<IActionResult> CreateContractAvarage()
        {
            


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContractAvarage(CreateContractAveragesVM vm)
        {
            var vam = vm;
            


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
