using FluentValidation;

namespace Application.Features.Ceremonies.Commands.Delete;

public class DeleteCeremonyCommandValidator : AbstractValidator<DeleteCeremonyCommand>
{
    public DeleteCeremonyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}