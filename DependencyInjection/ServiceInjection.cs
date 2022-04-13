
using CDG.Service.Interfaces;
using CDG.Service.Manage;
using DataAccess.Data.Interface;
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

namespace CDG.DependencyInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection ServiceConfiguration(this IServiceCollection services, IConfiguration Config)
        {
            services.AddSingleton<IAuthManage>
              (
                provider => 
                     new AuthManage(provider.GetService<IUnitOfWork>(), Config.GetConnectionString("MySecretKey"))
              );

            services.AddSingleton<IPersonManage, PersonManage>();
            services.AddSingleton<IAppointmentManage, AppointmentManage>();
            services.AddSingleton<IGaragePictureManage, GaragePictureManage>();
            services.AddSingleton<IReviewerPictureManage, ReviewerPictureManage>();
            services.AddSingleton<IReviewManage, ReviewManage>();
            services.AddSingleton<IProfilePictureManage, ProfilePictureManage>();
            services.AddSingleton<IEmailService>
                (
                    x => 
                       new EmailService(x.GetService<IAuthManage>(),
                       x.GetService<IUnitOfWork>().PersonRepository,
                       Config.GetConnectionString("EmailKey")
                ));
            return services;
        }
    }
}
