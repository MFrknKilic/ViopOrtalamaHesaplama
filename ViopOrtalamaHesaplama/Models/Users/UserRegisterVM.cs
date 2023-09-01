using System.ComponentModel.DataAnnotations;

namespace ViopOrtalamaHesaplama.UI.Models.Users
{
    public class UserRegisterVM
    {
        [Display(Name = "Adınız")]
        public string? FirstName { get; set; }
        [Display(Name = "Soyadınız")]
       
        public string? LastName { get; set; }
        [Display(Name = "Doğum Tarihiniz")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)] // Saat ve dakika bilgisi istememek için DataType belirtin
        public DateTime BirthDate { get; set; }
        [Display(Name = "Şifreniz")]
        public string? Password { get; set; }
        [Display(Name = "Telefon Numaranız")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "E-mail adresiniz")]
        public string? Email { get; set; }
        [Display(Name = "Ne iş yaparsınız")]
        public string? Job { get; set; }

    }
}
