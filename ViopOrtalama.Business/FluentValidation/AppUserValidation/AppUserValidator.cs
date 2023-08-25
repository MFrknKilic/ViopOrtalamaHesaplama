using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ViopOrtalama.Entities.Enitities;

namespace ViopOrtalama.Business.FluentValidation.AppUserValidation
{
   public class AppUserValidator :AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {

            RuleFor(x => x.FirstName)
          .NotEmpty()
          .WithName("Adı")
          .WithMessage("{PropertyName} alanı boş bırakılamaz.")
          .Length(2, 15)
          .WithName("Adı")
          .WithMessage("{PropertyName}  {MinLength} - {MaxLength} aralığında olmak zorundadır.")
          .Matches(new Regex(@"^[a-zA-ZıüöçşğİÜÖÇŞĞ]+$"))
           .WithMessage("lütfen Sadece harf girişi yapınız");

            RuleFor(x => x.SecondName)
                .Length(2, 15)
                .WithName("İkinci Adı")
                .WithMessage("{PropertyName}  {MinLength} - {MaxLength} aralığında olmak zorundadır.")
                .Matches(new Regex(@"^[a-zA-ZıüöçşğİÜÖÇŞĞ]+$"))
                .WithMessage("lütfen Sadece harf girişi yapınız");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithName("Soyadı")
                .WithMessage("{PropertyName} alanı boş bırakılamaz.")
                .Length(2, 15)
                .WithName("Soyadı")
                .WithMessage("{PropertyName}  {MinLength} - {MaxLength} aralığında olmak zorundadır.")
                .Matches(new Regex(@"^[a-zA-ZıüöçşğİÜÖÇŞĞ]+$"))
               .WithMessage("lütfen Sadece harf girişi yapınız");

            RuleFor(x => x.SecondLastName)
                .Length(2, 15)
                .WithName("İkinci Soyadı")
                .WithMessage("{PropertyName}  {MinLength} - {MaxLength} aralığında olmak zorundadır.")
                .Matches(new Regex(@"^[a-zA-ZıüöçşğİÜÖÇŞĞ]+$"))
               .WithMessage("lütfen Sadece harf girişi yapınız");

           

            RuleFor(x => x.BirthDate)
             .NotEmpty()
             .WithName("Doğum Tarihi")
             .WithMessage("{PropertyName} alanı boş bırakılamaz.")
             .Custom((date, context) =>
             {
                 DateTime from = new DateTime(1940, 1, 1);
                 DateTime to = DateTime.Now.AddYears(-12);
                 if (date < from)
                     context.AddFailure($"Doğum Tarihi {from.Date} tarihinden sonra olmalı");
                 else if (date > to)
                     context.AddFailure($"Doğum Tarihi {to.Day}.{to.Month}.{to.Year} tarihinden önce olmalı");
             });

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                 .WithName("Telefon Numarası")
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .Matches(new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"))
                .WithMessage("Lütfen geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithName("Şifre")
            .WithMessage("Şifre alanı boş olamaz.")
            .Matches(new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"))
            .WithMessage("Şifre en az 8 karakter uzunluğunda olmalı ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");

           
            RuleFor(x => x.Email)
                .NotEmpty().WithName("Email")
               .WithMessage("{PropertyName} alanı boş bırakılamaz.")
               .EmailAddress()
            .WithMessage("{PropertyName} formatında giriş yapınız.");

           
        }
    }
}
