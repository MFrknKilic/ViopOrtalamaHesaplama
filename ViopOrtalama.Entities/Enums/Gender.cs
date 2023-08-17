using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViopOrtalama.Entities.Enums
{
    public enum Gender
    {
        [Display(Name = "Hanımefendi")]
        Male =0,
        [Display(Name = "Beyfendi")]
        Female =1,
    }
}
