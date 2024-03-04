using MicroShop.IdentityService.Database.Contexts;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace MicroShop.IdentityService.Tests.Integration.Tools;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    private readonly Func<Task> _resetDatabaseTask;
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly IdentityDbContext DbContext;
    protected readonly UserManager<MicroShopUser> UserManager;
    protected HttpClient Client;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
        UserManager = _scope.ServiceProvider.GetRequiredService<UserManager<MicroShopUser>>();
        Client = factory.CreateClient();

        _resetDatabaseTask = factory.ResetDatabaseAsync;
    }

    public Task InitializeAsync()
    {
        return _resetDatabaseTask();
    } 

    public async Task DisposeAsync()
    {
        await _resetDatabaseTask();
        _scope?.Dispose();
        DbContext?.Dispose();
    }
}