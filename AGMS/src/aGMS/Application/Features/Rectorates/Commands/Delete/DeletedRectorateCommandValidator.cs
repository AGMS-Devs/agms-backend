using FluentValidation;

namespace Application.Features.Rectorates.Commands.Delete;

public class DeleteRectorateCommandValidator : AbstractValidator<DeleteRectorateCommand>
{
    public DeleteRectorateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}