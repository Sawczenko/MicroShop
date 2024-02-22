using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MicroShop.CatalogService.Database.Contexts;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Tools;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    private readonly Func<Task> _resetDatabaseTask;
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly CatalogDbContext DbContext;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<CatalogDbContext>();

        _resetDatabaseTask = factory.ResetDatabaseAsync;
    }

    protected CatalogDbContext GetCatalogDbContext()
    {
        return DbContext;
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        await _resetDatabaseTask();
        _scope?.Dispose();
        DbContext?.Dispose();
    }
}