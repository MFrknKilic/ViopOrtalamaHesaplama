using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViopOrtalama.Business.Abstract;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalamaHesaplama.UI.Models.Contracts;

namespace ViopOrtalamaHesaplama.UI.Controllers
{
    [Authorize]

    public class ContractAverages : Controller
    {

        private readonly IGenericService<Contract> _contractService;
        private readonly UserManager<AppUser> _userManager;

        public ContractAverages(UserManager<AppUser> userManager, IGenericService<Contract> contractService)
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
              .Where(g => g.Count() > 1)
              .SelectMany(g => g)
              .ToList();
            static ContractAvarageVM MapToAvarageVM(Contract contract)
            {
                return new ContractAvarageVM
                {
                    Company = contract.Company,
                    Expiry = contract.Expiry,
                    Position = contract.Position,
                    SelectedPosition = contract.Position,
                    Quantity = contract.Quantity,
                    Price = contract.Price,
                    // Ortalama değeri için hesaplama yapmanız gerekebilir.
                    // ContactAverage = ...
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
            List<Contract> contracts = _contractService.GetDefault(x => x.AppUser.Id == currentUser.Id)
                .GroupBy(x => new { x.Company, x.Expiry, x.Position })
                .Where(g => g.Count() > 1)
                .SelectMany(g => g)
                .ToList();

                      List<CompanyAvarages> contractAvarageVMs = contracts
               .GroupBy(c => new
               {
                   CompanyValue = c.Company.Value,
                   ExpiryValue = c.Expiry.Value,
                   PositionValue = c.Position
               })
               .Select(group => new CompanyAvarages
               {
                   Company = group.First().Company.Value,
                   Expiry = group.First().Expiry.Value,
                   Position = group.First().Position,
                   Quantity = group.Sum(c => c.Quantity),
                   Price = group.Sum(c => c.Quantity * c.Price),
                   ContactAverage = group.Average(c => c.Price),
                  
               })
               .ToList();


              return View(contractAvarageVMs);
        }





    }
}
