﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Tools
{
    public class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        }

    }
}
