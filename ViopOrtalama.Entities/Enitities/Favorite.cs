using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalama.Entities.Enitities
{
    public class Favorite:IBaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        [Display(Name = "Durum")]
        public Status Status { get; set; } = Status.Active;

        public List<Company>? Companies { get; set; }
        public List<Currency>? Currencies { get; set; }
        public List<Average>? Averages { get; set; }

        public AppUser AppUser { get; set; }

    }
}
