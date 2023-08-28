using System.ComponentModel.DataAnnotations;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalamaHesaplama.UI.Models.Contracts
{
    public class CompanyAvarages
    {

        public Company Company { get; set; }
        public Expiry Expiry { get; set; }
        public Position Position { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ContactAverage { get; set; }
    }
}
