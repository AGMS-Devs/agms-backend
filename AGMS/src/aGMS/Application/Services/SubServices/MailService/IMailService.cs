using System;

namespace Application.Services.SubServices.MailService;

public interface IMailService
{
    Task SendMailAsync(MailDto mailDto);
}

