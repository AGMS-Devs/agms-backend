using FluentValidation;

namespace Application.Features.Rectorates.Commands.Create;

public class CreateRectorateCommandValidator : AbstractValidator<CreateRectorateCommand>
{
    public CreateRectorateCommandValidator()
    {
        RuleFor(c => c.StudentAffairId).NotEmpty();
        RuleFor(c => c.StudentAffair).NotEmpty();
    }
}