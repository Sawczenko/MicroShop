using Microsoft.Extensions.DependencyInjection;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Pipelines
{
    public static class ServicesRegistration
    {
        public static void AddPipelines(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PaginationPipeline<,>));
        }
    }
}
