using FluentValidation.AspNetCore;
using ViopOrtalamaHesaplama.UI.FluentValidators.FluentFilter;

namespace ViopOrtalamaHesaplama.UI.FluentValidators.FluentValidationConfiguration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

            return services;
        }
    }
}

