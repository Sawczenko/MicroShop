using System.Drawing;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MicroShop.IdentityService.Database.Contexts;
using Microsoft.Extensions.DependencyInjection;
using MicroShop.IdentityService.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace MicroShop.IdentityService.Application.Features.Identity
{
    public static class Registration
    {
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddIdentity(services);
            AddAuthentication(services, configuration);
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
        }

        private static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<MicroShopUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        }
    }
}