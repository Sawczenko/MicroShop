using MicroShop.CatalogService.Application.Features.ProductBrands;
using MicroShop.CatalogService.Application.Features.ProductTypes;
using MicroShop.CatalogService.Application.Features.Products;
using MicroShop.CatalogService.Core.Containers;
using MicroShop.Catalog.Application.Services;
using MicroShop.Core.Features.Telemetry;
using MicroShop.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Properties/appsettings.json");
// Add services to the container.

builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCatalogDatabase(builder.Configuration);
builder.Services.AddMapper();
builder.Services.AddContainers();
builder.Services.AddProducts();
builder.Services.AddProductTypes();
builder.Services.AddProductBrands();

builder.Services.UseMicroShopCore(AppDomain.CurrentDomain.GetAssemblies()).WithTelemetry(config =>
{
    config.ServiceVersion = "1.0";
    config.ServiceName = "CatalogService";
    config.OtlpEndpoint = "http://localhost:4317";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

    app.UseSwagger();
    app.UseSwaggerUI();

    app.SeedDatabase();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
