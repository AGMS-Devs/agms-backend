using FluentValidation;

namespace Application.Features.MailLogs.Commands.Create;

public class CreateMailLogCommandValidator : AbstractValidator<CreateMailLogCommand>
{
    public CreateMailLogCommandValidator()
    {
        RuleFor(c => c.SentDate).NotEmpty();
        RuleFor(c => c.From).NotEmpty();
        RuleFor(c => c.To).NotEmpty();
        RuleFor(c => c.Subject).NotEmpty();
        RuleFor(c => c.Body).NotEmpty();
        RuleFor(c => c.IsBodyHtml).NotEmpty();
        RuleFor(c => c.IsSentSuccessfully).NotEmpty();
        RuleFor(c => c.ErrorMessage).NotEmpty();
    }
}