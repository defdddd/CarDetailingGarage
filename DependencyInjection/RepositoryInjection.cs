using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DataAccess.Connection;
using DataAccess.SqlDataAccess;
using DataAccess.Data;

namespace DependencyInjection
{
    public static class RepositoryInjection
    {
        public static IServiceCollection RepositoryConfiguration(this IServiceCollection services, IConfiguration Config)
        {
            services.AddSingleton<IConnection>(new Connection(Config.GetConnectionString("DataBase")));
            services.AddSingleton<ISqlDataAccess,SqlDataAccess>();

            //services.AddSingleton<IAppointmentRepo, AppointmentRepo>();
            services.AddSingleton<IPersonData, PersonData>();
            //services.AddSingleton<IReviewRepo, ReviewRepo>();
            //services.AddSingleton<IReviewerPictureRepo, ReviewerPictureRepo>();
            //services.AddSingleton<IGaragePictureRepo, GaragePictureRepo>();

            return services;
        }
    }
}
