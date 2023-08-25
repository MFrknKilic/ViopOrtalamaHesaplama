﻿using System.ComponentModel.DataAnnotations;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalamaHesaplama.UI.Models.Contracts
{
    public class CreateContractCurrencyVM
    {
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Vade")]
        public Expiry? Expiry { get; set; }

        [Display(Name = "Parite")]
        public Currency? Currency { get; set; }

        public Position? Position { get; set; }
        public Position SelectedPosition { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        public AppUser AppUser { get; set; }
    }
}
