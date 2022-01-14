using CDG.Validation.Model.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.DependencyInjection
{
    public static class ValidatorInjection
    {
        public static IServiceCollection ValidationConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<PersonModel>, PersonValidator>();
            services.AddSingleton<IValidator<AppointmentModel>, AppointmentValidator>();
            services.AddSingleton<IValidator<ReviewModel>, ReviewValidator>();
            services.AddSingleton<IValidator<GaragePictureModel>, GaragePictureValidator>();
            services.AddSingleton<IValidator<ReviewerPictureModel>, ReviewerPictureValidator>();

            return services;
        }
    }
}
