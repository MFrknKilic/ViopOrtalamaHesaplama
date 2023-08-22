using System.ComponentModel.DataAnnotations;

namespace ViopOrtalamaHesaplama.UI.Models
{
    public class LoginVM
    {
        [Display(Name = "Mail")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
