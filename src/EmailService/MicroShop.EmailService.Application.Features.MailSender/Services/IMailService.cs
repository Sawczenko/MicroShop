using MicroShop.EmailService.Application.Features.MailSender.Models;

namespace MicroShop.EmailService.Application.Features.MailSender.Services;

public interface IMailService
{
    public bool SendMail(MailData mailData);
}