using MicroShop.CatalogService.Database.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Testcontainers.MsSql;
using Xunit;
using System.Data.Common;
using Respawn;
using MicroShop.Core.Interfaces.Database;
using Microsoft.Data.SqlClient;
using Respawn.Graph;
using System.Collections.Generic;
using System.Data;

namespace MicroShop.CatalogService.Tests.Integration.Tools;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2019-latest")
        .WithPassword("Strong_password_123!")
        .Build();

    private SqlConnection sqlConnection;
    private DbConnection _dbConnection = default!;
    private Respawner _respawner = default!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<CatalogDbContext>));

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<CatalogDbContext>(options =>
                options.UseSqlServer(_dbContainer.GetConnectionString()));
        });
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        _dbConnection = new SqlConnection(_dbContainer.GetConnectionString());

        await InitializeRespawner();
    }

    private async Task InitializeRespawner()
    {
        await _dbConnection.OpenAsync();

        var options = new DbContextOptionsBuilder<CatalogDbContext>().UseSqlServer(_dbContainer.GetConnectionString()).Options;

        var dbContext = new CatalogDbContext(options);
        dbContext.Database.EnsureCreated();

        _respawner = await Respawner.CreateAsync(_dbConnection, new RespawnerOptions
        {

            SchemasToInclude = new[]
                {
                    "dbo"
                },
            DbAdapter = DbAdapter.SqlServer,
            CommandTimeout = 60
        });
    }

    public Task ResetDatabaseAsync()
    {
        return _respawner.ResetAsync(_dbConnection);
    }


    public new Task DisposeAsync()
    {
        return _dbContainer.StopAsync();
    }
}