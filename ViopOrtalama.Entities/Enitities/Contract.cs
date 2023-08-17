using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalama.Entities.Enitities
{
    public class Contract : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        [Display(Name = "Durum")]
        public Status Status { get; set; } = Status.Active;
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
        public Position Position { get; set; }

        public decimal Price { get; set; }

        public AppUser AppUser { get; set; }

        public Average MyProperty { get; set; }

       
    }
}
