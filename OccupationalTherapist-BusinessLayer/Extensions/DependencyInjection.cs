using Microsoft.Extensions.DependencyInjection;
using OccupationalTherapist_BusinessLayer.Managers.Abstract;
using OccupationalTherapist_BusinessLayer.Managers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IAppointmentService, AppointmentManager>();

            return services;
        }
    }
}
