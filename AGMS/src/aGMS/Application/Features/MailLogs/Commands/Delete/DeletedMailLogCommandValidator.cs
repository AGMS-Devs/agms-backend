using FluentValidation;

namespace Application.Features.MailLogs.Commands.Delete;

public class DeleteMailLogCommandValidator : AbstractValidator<DeleteMailLogCommand>
{
    public DeleteMailLogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}