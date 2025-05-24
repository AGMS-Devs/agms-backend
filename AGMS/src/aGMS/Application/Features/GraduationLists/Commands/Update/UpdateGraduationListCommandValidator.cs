using FluentValidation;

namespace Application.Features.GraduationLists.Commands.Update;

public class UpdateGraduationListCommandValidator : AbstractValidator<UpdateGraduationListCommand>
{
    public UpdateGraduationListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.GraduationListNumber).NotEmpty();
        RuleFor(c => c.AdvisorId).NotEmpty();
        RuleFor(c => c.Advisor).NotEmpty();
    }
}