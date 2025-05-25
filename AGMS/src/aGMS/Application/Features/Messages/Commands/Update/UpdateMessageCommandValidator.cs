using FluentValidation;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Message ID is required");
        RuleFor(c => c.Content).NotEmpty().WithMessage("Message content is required");
        RuleFor(c => c.IsRead).NotNull().WithMessage("IsRead status is required");
    }
}