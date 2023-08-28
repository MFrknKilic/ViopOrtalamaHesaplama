using System.ComponentModel.DataAnnotations;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalamaHesaplama.UI.Models.Contracts
{
    public class ContractAvarageVM
    {
        [Display(Name = "Şirket")]
        public Company? Company { get; set; }
        [Display(Name = "Vade")]
        public Expiry? Expiry { get; set; }
       
        [Display(Name = "Pozisyon")]
        public Position? Position { get; set; }
        [Display(Name = "Pozisyon")]
        public Position SelectedPosition { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Ortalama")]
        public decimal ContactAverage { get; set; }

        public AppUser AppUser { get; set; }
    }
}
