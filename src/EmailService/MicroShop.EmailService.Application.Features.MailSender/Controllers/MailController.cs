using MicroShop.EmailService.Application.Features.MailSender.Services;
using MicroShop.EmailService.Application.Features.MailSender.Models;
using MicroShop.Core.Abstractions.Controllers.Controllers;
using MicroShop.Core.Interfaces.Containers.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace MicroShop.EmailService.Application.Features.MailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public bool SendMail(MailData mailData)
        {
            return _mailService.SendMail(mailData);
        }
    }
}
