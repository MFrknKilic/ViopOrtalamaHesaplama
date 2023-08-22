using System.ComponentModel.DataAnnotations;

namespace ViopOrtalamaHesaplama.UI.Models
{
    public class SingUpViewModel
    {
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "E-posta alanı zorunlu")]
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Şifre kriterlere uymuyor. ( ℹ️ )")]
        [Required(ErrorMessage = "Şifre alanı zorunlu")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
