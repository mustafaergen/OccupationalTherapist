using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OccupationalTherapist_DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccessLayer.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(AppDbContext.ConnectionString),
                    options => options.EnableRetryOnFailure(
                        10,
                        TimeSpan.FromSeconds(10),
                        null));
                options.UseLazyLoadingProxies();
            });

            return services;
        }
    }
}
