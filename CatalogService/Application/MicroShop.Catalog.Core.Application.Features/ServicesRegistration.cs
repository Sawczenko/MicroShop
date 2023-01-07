
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Catalog.Core.Application.Features
{
    public static class ServicesRegistration
    {
        public static void AddFeatures(this IServiceCollection services)
        {
            services.AddMediator(options =>
            {
                options.ServiceLifetime = ServiceLifetime.Scoped;
            });
        }
    }
}
