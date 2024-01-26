using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.CatalogService.Application.Features.ProductBrands
{
    public static class Registration
    {
        public static void AddProductBrands(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}