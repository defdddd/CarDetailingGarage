using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection ServiceConfiguration(this IServiceCollection services)
        {     
            return services;
        }
    }
}
