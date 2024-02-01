using MediatR;
using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.CatalogService.Database.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Tools
{
    public class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;

        public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        }

        protected CatalogDbContext GetCatalogDbContext()
        {
            return _scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
        }
    }
}
