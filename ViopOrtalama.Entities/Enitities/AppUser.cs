using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Adı")]
        public string FirstName { get; set; }
        [Display(Name = "İkinci Adı")]
        public string SecondName { get; set; }
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }
        [Display(Name = "İkinci Soyadı")]
        public string SecondLastName { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Telefon Numarası")]
        public override string PhoneNumber { get; set; }
        [Display(Name = "Takipçi Sayısı")]
        public int? Followers { get; set; }
        [Display(Name = "T.C. Kimlik Numarası")]
        public string CitizenId { get; set; }
        [Display(Name = "Uyruk")]
        public string Country { get; set; }
        [Display(Name = "Meslek")]
        public string Job { get; set; }
        public List<Contract>? Contracts { get; set; }
        public List<Favorite>? Favorites { get; set; }
    }
}
