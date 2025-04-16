using Microsoft.Extensions.DependencyInjection;
using OccupationalTherapist_DataAccess.EFCore.Abstracts;
using OccupationalTherapist_DataAccess.EFCore.Repositories;
using OccupationalTherapist_DataAccess.Interface.Abstracts;
using OccupationalTherapist_DataAccess.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.EFCore.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}
