using System;

namespace Application.Services.SubServices.MailService;

public class MailDto
{
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsBodyHtml { get; set; } = false;
}

  
