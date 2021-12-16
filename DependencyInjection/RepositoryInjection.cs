using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using DataAccess.SqlDataAccess;
using DataAccess.UnitOfWork;

namespace DependencyInjection
{
    public static class RepositoryInjection
    {
        public static IServiceCollection RepositoryConfiguration(this IServiceCollection services, IConfiguration Config)
        {
            services.AddSingleton<ISqlDataAccess>(new SqlDataAccess(Config.GetConnectionString("DataBase")));
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
