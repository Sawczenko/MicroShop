using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.CatalogService.Application.Features.Products
{
    public static class Registration
    {
        public static void AddProducts(this IServiceCollection services)
        {
            services.AddMediatR(x=> x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
