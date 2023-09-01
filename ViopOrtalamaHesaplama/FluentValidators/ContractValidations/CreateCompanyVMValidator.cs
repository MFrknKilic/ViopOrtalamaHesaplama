using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Entities.Enums;
using ViopOrtalamaHesaplama.UI.Models.Contracts;

namespace ViopOrtalamaHesaplama.UI.FluentValidators.ContractValidations
{
    public class CreateCompanyVMValidator : AbstractValidator<CreateContractCompanyVM>
    {
        public CreateCompanyVMValidator()

        {
                       RuleFor(x => x.Quantity)
                  .NotEmpty().WithName("Miktar")
                  .WithMessage("{PropertyName} alanı boş bırakılamaz.").InclusiveBetween(0, 1000)
                  .WithMessage("{PropertyName} Miktar alanı boş bırakılamaz.");

                       RuleFor(x => x.Expiry)
                   .NotEmpty()
                   .WithName("Kontrat Tarihi")
                   .WithMessage("Hangi Kontrat Tarihini Seçiniz");

                    RuleFor(x => x.Price)
                 .NotEmpty()
                 .WithName("Fiyat")
                 .WithMessage("Fiyat giriniz");


                        RuleFor(x => x.Company)
                 .NotEmpty()
                 .WithName("Şirket")
                 .WithMessage("Şirket Seçiniz");



                        RuleFor(x => x.SelectedPosition)
                .NotEmpty()
                .WithName("Pozisyon")
                .WithMessage("Long veya short belirtmediniz");





        }
    }
}
