using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ViopOrtalama.Entities.Enums;

namespace ViopOrtalama.Entities.Enitities
{
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        [Display(Name = "Durum")]
        public Status Status { get; set; } = Status.Active;
        private string _email;
      
        public override string Email
        {
            get { return _email; }
            set { _email = value; NormalizedEmail = value?.Normalize().ToLower(); }
        }

        [Display(Name = "Adı")]
        public string FirstName { get; set; }
      
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }
        
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
      
        [Display(Name = "Telefon Numarası")]
        public  string PhoneNumber { get; set; }
        [Display(Name = "Telefon Numarası")]
        public int ConfirmCode { get; set; }

        [Display(Name = "Meslek")]
        public string Job { get; set; }
        public List<Contract>? Contracts { get; set; }
        public List<Favorite>? Favorites { get; set; }
    }
}
