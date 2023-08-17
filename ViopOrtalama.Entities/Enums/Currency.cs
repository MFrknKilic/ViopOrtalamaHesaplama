using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViopOrtalama.Entities.Enums
{
    public enum Currency
    {
        [Display(Name = "Euro/Tl")]
        EURTRY =1,
        [Display(Name = "Dolar/TL")]
        USDTRY =2,
        [Display(Name = "ÇinYunaı/TL")]
        CNHTRY =3,
        [Display(Name = "Ruble/TL")]
        RUBTRY =4,
        [Display(Name = "Euro/Dolar")]
        EURUSD =5,
        [Display(Name = "Sterlin/Dolar")]
        GBPUSD =6,
        
    }
}
