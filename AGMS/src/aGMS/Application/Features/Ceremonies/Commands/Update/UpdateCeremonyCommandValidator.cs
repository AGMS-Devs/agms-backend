using FluentValidation;

namespace Application.Features.Ceremonies.Commands.Update;

public class UpdateCeremonyCommandValidator : AbstractValidator<UpdateCeremonyCommand>
{
    public UpdateCeremonyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CeremonyDate).NotEmpty();
        RuleFor(c => c.CeremonyLocation).NotEmpty();
        RuleFor(c => c.CeremonyDescription).NotEmpty();
        RuleFor(c => c.CeremonyStatus).NotEmpty();
        RuleFor(c => c.AcademicYear).NotEmpty();
        RuleFor(c => c.StudentAffairsId).NotEmpty();
        RuleFor(c => c.StudentAffair).NotEmpty();
    }
}