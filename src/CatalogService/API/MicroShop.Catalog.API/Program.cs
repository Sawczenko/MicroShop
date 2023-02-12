using MicroShop.Core.Abstractions.Containers;
using MicroShop.Core.Abstractions.Mediator;
using MicroShop.Core.Abstractions.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Properties/appsettings.json");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services.AddServices(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddContainers();
builder.Services.AddMediator(AppDomain.CurrentDomain.GetAssemblies());

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
