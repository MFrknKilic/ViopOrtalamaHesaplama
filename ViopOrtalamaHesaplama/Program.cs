using FormHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using ViopOrtalama.Business.Abstract;
using ViopOrtalama.Business.Concrate;
using ViopOrtalama.Entities.Enitities;
using ViopOrtalama.Repositories;
using ViopOrtalama.Repositories.Abstract;
using ViopOrtalama.Repositories.Concrete;
using ViopOrtalama.Repositories.Context;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Hizmetlerin eklenmesi ve yapýlandýrýlmasý
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFormHelper();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddDbContext<ViopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Viop"));
});
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    
    
  
}).AddEntityFrameworkStores<ViopDbContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);


builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

var env = app.Environment; // IWebHostEnvironment

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
