using DB.Repository.Interfaces;
using DB.Repository.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public static class RepositoryInjection
    {
        public static IServiceCollection RepositoryConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentRepo, AppointmentRepo>();

            return services;
        }
    }
}
