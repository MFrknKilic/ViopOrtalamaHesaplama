using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViopOrtalama.Entities.Enitities;

namespace ViopOrtalama.Repositories.Context
{
    public class ViopDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
       
        public ViopDbContext(DbContextOptions<ViopDbContext> options) : base(options)
        {

        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

    }

}

