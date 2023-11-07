using MicroShop.IdentityService.Application.Features.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.IdentityService.Application.Features
{
    public static class Registration
    {
        public static void AddFeatures(this IServiceCollection services)
        {
            services.AddAuthentication();
        }
    }
}