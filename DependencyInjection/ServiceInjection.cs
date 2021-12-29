﻿
using DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection ServiceConfiguration(this IServiceCollection services, IConfiguration Config)
        {
            services.AddSingleton<IJwtManage>
              (
                provider => 
                     new JwtManage(provider.GetService<IUnitOfWork>(), Config.GetConnectionString("MySecretKey"))
              );

            services.AddSingleton<IPersonManage, PersonManage>();
            services.AddSingleton<IAppointmentManage, AppointmentManage>();
            services.AddSingleton<IGaragePictureManage, GaragePictureManage>();
            services.AddSingleton<IReviewerPictureManage, ReviewerPictureManage>();
            services.AddSingleton<IReviewManage, ReviewManage>();
            return services;
        }
    }
}
