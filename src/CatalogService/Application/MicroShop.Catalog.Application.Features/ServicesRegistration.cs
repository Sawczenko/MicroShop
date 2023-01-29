using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MicroShop.Catalog.Application.Features
{
    public static class ServicesRegistration
    {
        public static void AddFeatures(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
