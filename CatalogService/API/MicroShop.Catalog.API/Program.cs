using MicroShop.Catalog.Core.Application.Containers;
using MicroShop.Catalog.Core.Application.Pipelines;
using MicroShop.Catalog.Core.Application.Features;
using MicroShop.Catalog.Database;
using MicroShop.Catalog.Core.Application.Models;
using MicroShop.Catalog.Core.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Properties/appsettings.json");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPipelines();
builder.Services.AddServices();
builder.Services.AddContainers();
builder.Services.AddFeatures();

builder.Services.AddCatalogDatabase(builder.Configuration);

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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
