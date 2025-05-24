using Application.Constants;
using Application.Features.Auth.Constants;
using Application.Features.Auth.Rules;
using Application.Services.MailLogs;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.Hashing;
using System.Security.Cryptography;
using System.Text;
using Application.Features.MailLogs.Commands.Create;
using Microsoft.Extensions.Options;

namespace Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest<ResetPasswordResponse>
{
    public string Email { get; set; } = string.Empty;

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;
        private readonly IMailLogService _mailLogService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMediator _mediator;

        public ResetPasswordCommandHandler(IUserRepository userRepository, IMailService mailService, IMailLogService mailLogService, AuthBusinessRules authBusinessRules, IMediator mediator)
        {
            _userRepository = userRepository;
            _mailService = mailService;
            _authBusinessRules = authBusinessRules;
            _mailLogService = mailLogService;
            _mediator = mediator;
            
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Email == request.Email, cancellationToken: cancellationToken);
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);

            string newPassword = GenerateRandomPassword(10);
            HashingHelper.CreatePasswordHash(newPassword, out var hash, out var salt);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            await _userRepository.UpdateAsync(user);

            string htmlBody = MailTemplates.PasswordReset.GetBody(newPassword, user.Name ?? user.Email);
            

            await _mailService.SendEmailAsync(new Mail
            {
                ToList = new List<MailboxAddress> { new("", user.Email) },
                Subject = MailTemplates.PasswordReset.SUBJECT,
                HtmlBody = htmlBody
            });
            
            await _mediator.Send(new CreateMailLogCommand
            {
                SentDate = DateTime.UtcNow,
                From = "nadircan2003@gmail.com",
                To = user.Email,
                Subject = MailTemplates.PasswordReset.SUBJECT,
                Body = htmlBody,
                IsBodyHtml = true,
                IsSentSuccessfully = true,
                ErrorMessage = "mail sent successfully"
            });

            return new ResetPasswordResponse(AuthMessages.ResetPasswordMailSent);
        }

        private string GenerateRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder res = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];
                while (res.Length < length)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return res.ToString();
        }
    }
}