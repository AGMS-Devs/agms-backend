using FluentValidation;

namespace Application.Features.Ceremonies.Commands.Create;

public class CreateCeremonyCommandValidator : AbstractValidator<CreateCeremonyCommand>
{
    public CreateCeremonyCommandValidator()
    {
        RuleFor(c => c.CeremonyDate).NotEmpty();
        RuleFor(c => c.CeremonyLocation).NotEmpty();
        RuleFor(c => c.CeremonyDescription).NotEmpty();
        RuleFor(c => c.CeremonyStatus).NotEmpty();
        RuleFor(c => c.AcademicYear).NotEmpty();
        RuleFor(c => c.StudentAffairsId).NotEmpty();
        RuleFor(c => c.StudentAffair).NotEmpty();
    }
}