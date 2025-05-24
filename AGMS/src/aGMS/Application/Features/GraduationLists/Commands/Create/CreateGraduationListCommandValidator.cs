using FluentValidation;

namespace Application.Features.GraduationLists.Commands.Create;

public class CreateGraduationListCommandValidator : AbstractValidator<CreateGraduationListCommand>
{
    public CreateGraduationListCommandValidator()
    {
        RuleFor(c => c.GraduationListNumber).NotEmpty();
        RuleFor(c => c.AdvisorId).NotEmpty();
        RuleFor(c => c.Advisor).NotEmpty();
    }
}