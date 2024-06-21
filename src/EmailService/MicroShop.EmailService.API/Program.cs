using MicroShop.Core.Features.Telemetry;
using MicroShop.Core.Middlewares;
using MicroShop.Core;
using MicroShop.EmailService.Application.Features.MailSender;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Properties/appsettings.json");

// Add services to the container.

builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMailSender(builder.Configuration);

builder.Services
    .UseMicroShopCore(AppDomain.CurrentDomain.GetAssemblies())
    .WithTelemetry(configuration =>
    {
        configuration.ServiceVersion = "1.0";
        configuration.ServiceName = "EmailService";
        configuration.OtlpEndpoint = "http://localhost:4317";
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
}

app.UseMicroShopCoreErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
