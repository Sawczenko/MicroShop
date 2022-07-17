using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Catalog.Code.Domain.Application
{
    public static class ServicesRegistration
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServicesRegistration));
        }
    }
}
