using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViopOrtalama.Entities.Enums
{
    public enum Commodity
    {
        [Display(Name = "SpotAltın/Dolar")]
        XAUUSD = 1,
        [Display(Name = "SpotGümüş/Dolar")]
        XAGUSD = 2,
        [Display(Name = "SpotAltın/TL")]
        XAUTRY = 3,
        [Display(Name = "SpotPaladyum/Dolar")]
        XPDUSD = 4,
        [Display(Name = "SpotPlatinyum/Dolar")]
        XPTUSD = 5
    }
}
