using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MicroShop.CatalogService.Application.Features.ProductTypes
{
    public static class Registration
    {
        public static void AddProductTypes(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}