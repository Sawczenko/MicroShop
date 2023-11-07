using MicroShop.IdentityService.Application.Features.Authentication;
using MicroShop.IdentityService.Application.Features.Identity;
using MicroShop.IdentityService.Core.Containers;
using MicroShop.Catalog.Application.Services;
using MicroShop.Core.Features.Telemetry;
using MicroShop.Core;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("Properties/appsettings.json");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapper();
builder.Services.AddContainers();
builder.Services.AddIdentity(builder.Configuration);
builder.Services.AddAuthenticationFeatures();

builder.Services.UseMicroShopCore(AppDomain.CurrentDomain.GetAssemblies()).WithTelemetry(config =>
{
    config.ServiceVersion = "1.0";
    config.ServiceName = "IdentityService";
    config.OtlpEndpoint = "http://localhost:4317";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
