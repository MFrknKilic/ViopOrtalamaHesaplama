using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViopOrtalama.Entities.Enums
{
    public enum Expiry
    {
        [Display(Name = "Ocak")]
        January = 1,
        [Display(Name = "Şubat")]
        February = 2,
        [Display(Name = "Mart")]
        March = 3,
        [Display(Name = "Nisan")]
        April = 4,
        [Display(Name = "Mayıs")]
        May = 5,
        [Display(Name = "Haziran")]
        June = 6,
        [Display(Name = "Temmuz")]
        July = 7,
        [Display(Name = "Ağustos")]
        August = 8,
        [Display(Name = "Eylül")]
        September = 9,
        [Display(Name = "Ekim")]
        October = 10,
        [Display(Name = "Kasım")]
        November = 11,
        [Display(Name = "Aralık")]
        December = 12,
    }
}
