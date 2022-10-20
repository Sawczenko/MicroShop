using Microsoft.Extensions.DependencyInjection;
using MediatR;


namespace MicroShop.Catalog.Core.Application.Features
{
    public static class ServicesRegistration
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServicesRegistration));
        }
    }
}
