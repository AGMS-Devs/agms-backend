using FluentValidation;

namespace Application.Features.MailLogs.Commands.Update;

public class UpdateMailLogCommandValidator : AbstractValidator<UpdateMailLogCommand>
{
    public UpdateMailLogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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