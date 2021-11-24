using DB.Repository.Interfaces;
using DB.Repository.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DB.Repository;

namespace DependencyInjection
{
    public static class RepositoryInjection
    {
        public static IServiceCollection RepositoryConfiguration(this IServiceCollection services, IConfiguration Config)
        {
            services.AddSingleton<IConnection>(new Connection(Config.GetConnectionString("DataBase")));
            services.AddSingleton<IAppointmentRepo, AppointmentRepo>();
            services.AddSingleton<IPersonRepo, PersonRepo>();
            services.AddSingleton<IReviewRepo, ReviewRepo>();
            services.AddSingleton<IReviewerPictureRepo, ReviewerPictureRepo>();
            services.AddSingleton<IGaragePictureRepo, GaragePictureRepo>();

            return services;
        }
    }
}
