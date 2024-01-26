using MicroShop.CatalogService.Application.Features.ProductBrands;
using MicroShop.CatalogService.Application.Features.ProductTypes;
using MicroShop.CatalogService.Application.Features.Products;
using MicroShop.CatalogService.Core.Containers;
using MicroShop.Catalog.Application.Services;
using MicroShop.Core.Features.Telemetry;
using MicroShop.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Properties/appsettings.json");
// Add services to the container.

builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services
    .UseMicroShopCore(AppDomain.CurrentDomain.GetAssemblies())
    .WithTelemetry(configuration => {
        configuration.ServiceVersion = "1.0";
        configuration.ServiceName = "CatalogService";
        configuration.OtlpEndpoint = "http://localhost:4317";
    });

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddMapper();
builder.Services.AddContainers();
builder.Services.AddProducts();
builder.Services.AddProductTypes();
builder.Services.AddProductBrands();

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


public partial class Program {}