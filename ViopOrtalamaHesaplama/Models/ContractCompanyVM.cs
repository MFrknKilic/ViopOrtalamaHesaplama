using System.ComponentModel.DataAnnotations;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalamaHesaplama.UI.Models
{
    public class ContractCompanyVM
    {
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Vade")]
        public Expiry? Expiry { get; set; }
        [Display(Name = "Şirket")]
        public Company? Company { get; set; }
        [Display(Name = "Parite")]
        public Currency? Currency { get; set; }
        [Display(Name = "Emtia")]
        public Commodity? Commodity { get; set; }
        [Display(Name = "Endeks")]
        public Average? Averages { get; set; }
        public Position? Position { get; set; }
        public Position SelectedPosition { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        public AppUser AppUser { get; set; }

    }
}
