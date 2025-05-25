using FluentValidation;
using Domain.Enums;

namespace Application.Features.Ceremonies.Commands.Update;

public class UpdateCeremonyCommandValidator : AbstractValidator<UpdateCeremonyCommand>
{
    public UpdateCeremonyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CeremonyDate).NotEmpty();
        RuleFor(c => c.CeremonyLocation).NotEmpty();
        RuleFor(c => c.CeremonyDescription).NotEmpty();
        RuleFor(c => c.CeremonyStatus).IsInEnum().WithMessage("Geçerli bir tören durumu seçiniz (0: Beklemede, 1: Onaylandı, 2: Reddedildi)");
        RuleFor(c => c.AcademicYear).NotEmpty();
        RuleFor(c => c.StudentAffairsId).NotEmpty();
    }
}