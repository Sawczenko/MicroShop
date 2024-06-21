
using MicroShop.EmailService.Application.Features.MailSender.Services;
using MicroShop.EmailService.Application.Features.MailSender.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MicroShop.EmailService.Application.Features.MailSender
{
    public static class Registration
    {
        public static void AddMailSender(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService>();
        }
    }
}
