using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_DataAccessLayer.Context;
using System.Reflection;

namespace OccupationalTherapist_UI.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMvcServices(this IServiceCollection services)
        {
            services
                .AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
                .AddRazorRuntimeCompilation();

            services.AddSession();
            return services;
        }
        
    }
}
