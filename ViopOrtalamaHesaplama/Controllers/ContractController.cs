using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ViopOrtalama.Business.Abstract;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalamaHesaplama.UI.Models.Contracts;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    [Authorize]

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

            string priceString = ccvm.Price.Replace(',', '.'); // Virgül yerine nokta kullanımını desteklemek için
            contract.Price = decimal.Parse(priceString, CultureInfo.InvariantCulture);
            contract.Company = ccvm.Company;
            contract.Expiry = ccvm.Expiry;
            contract.Position = ccvm.SelectedPosition;
            contract.AppUser.Id = currentUser.Id;
            _contractService.Add(contract);

            return RedirectToAction("ContractAverageOpenOnes", "ContractAverages");

        }
       
        [HttpPost]
        public async Task<IActionResult> DeleteContract(int contractID)
        {
            Contract contract=_contractService.GetById(contractID);
            _contractService.Remove(contract);
            return RedirectToAction("ContractAverageOpenOnes", "ContractAverages");

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
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            Contract contract = new Contract();

            contract.AppUser = currentUser;
            contract.Quantity = cccvm.Quantity;
            contract.Price = cccvm.Price;
            contract.Commodity = cccvm.Commodity;
            contract.Expiry = cccvm.Expiry;
            contract.Position = cccvm.SelectedPosition;
            contract.AppUser.Id = currentUser.Id;
            _contractService.Add(contract);



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
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            Contract contract = new Contract();

            contract.AppUser = currentUser;
            contract.Quantity = cccurencyvm.Quantity;
            contract.Price = cccurencyvm.Price;
            contract.Currency = cccurencyvm.Currency;
            contract.Expiry = cccurencyvm.Expiry;
            contract.Position = cccurencyvm.SelectedPosition;
            contract.AppUser.Id = currentUser.Id;
            _contractService.Add(contract);


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
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            Contract contract = new Contract();

            contract.AppUser = currentUser;
            contract.Quantity = vm.Quantity;
            contract.Price = vm.Price;
            contract.Averages = vm.Averages;
            contract.Expiry = vm.Expiry;
            contract.Position = vm.SelectedPosition;
            contract.AppUser.Id = currentUser.Id;
            _contractService.Add(contract);



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
