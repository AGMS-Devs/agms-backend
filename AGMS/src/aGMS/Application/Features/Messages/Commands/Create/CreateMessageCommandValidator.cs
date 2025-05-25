using FluentValidation;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(c => c.Content).NotEmpty().WithMessage("Message content is required");
        RuleFor(c => c.StudentNumber).NotEmpty().WithMessage("Student number is required");
    }
}