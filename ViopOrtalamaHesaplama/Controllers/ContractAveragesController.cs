using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViopOrtalama.Business.Abstract;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalamaHesaplama.UI.Models.Contracts;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    [Authorize]

    public class ContractAveragesController : Controller
    {

        private readonly IGenericService<Contract> _contractService;
        private readonly UserManager<AppUser> _userManager;

        public ContractAveragesController(UserManager<AppUser> userManager, IGenericService<Contract> contractService)
        {
            _contractService = contractService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ContractAverageOpenOnes()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            List<Contract> contracts = _contractService.GetDefault(x => x.AppUser.Id == currentUser.Id)
              .GroupBy(x => new { x.Company, x.Expiry, x.Position })
              .Where(g => g.Count() > 0)
              .SelectMany(g => g)
               .OrderByDescending(c => c.CreateDate)
              .ToList();
            static ContractAvarageVM MapToAvarageVM(Contract contract)
            {
                return new ContractAvarageVM
                {
                    ContractID = contract.Id,
                    Company = contract.Company,
                    Expiry = contract.Expiry,
                    Position = contract.Position,
                    SelectedPosition = contract.Position,
                    Quantity = contract.Quantity,
                    Price = contract.Price,
                    
                };
            }

            List<ContractAvarageVM> contractAvarageVMs = contracts.Select(c => MapToAvarageVM(c)).ToList();
            return View(contractAvarageVMs);
        }


        [HttpGet]
        public async Task<IActionResult> ContractAverageOnExpiry()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ContractAveragesCompany()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            // Kullanıcının işlemlerini al
            List<Contract> contracts = _contractService.GetDefault(x => x.AppUser.Id == currentUser.Id)
                .ToList();

            // Şirket, vade ve pozisyon özelliklerine göre gruplandır
            var groupedContracts = contracts.GroupBy(c => new
            {
                Company = c.Company.Value,
                Expiry = c.Expiry.Value,
                Position = c.Position
            });

            // Her grup için adet ve fiyat özelliklerini çarp ve ortalamayı hesapla
            List<CompanyAvarages> contractAvarageVMs = new List<CompanyAvarages>();
            foreach (var group in groupedContracts)
            {
                var totalQuantity = group.Sum(c => c.Quantity);
                var totalPrice = group.Sum(c => c.Quantity * c.Price);
                var companyAverages = new CompanyAvarages
                {
                    Company = group.Key.Company,
                    Expiry = group.Key.Expiry,
                    Position = group.Key.Position,
                    Quantity = totalQuantity,
                    Price = totalPrice,
                    ContactAverage = totalQuantity > 0 ? totalPrice / totalQuantity : 0
                };

                contractAvarageVMs.Add(companyAverages);
            }

            return View(contractAvarageVMs);
        }





    }
}
