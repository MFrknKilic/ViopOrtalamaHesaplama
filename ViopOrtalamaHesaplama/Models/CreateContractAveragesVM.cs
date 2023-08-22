using System.ComponentModel.DataAnnotations;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalamaHesaplama.UI.Models
{
    public class CreateContractAveragesVM
    {
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Vade")]
        public Expiry? Expiry { get; set; }
        [Display(Name = "Endeks")]
        public Average? Averages { get; set; }
        public Position? Position { get; set; }
        public Position SelectedPosition { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        public AppUser AppUser { get; set; }
    }
}
