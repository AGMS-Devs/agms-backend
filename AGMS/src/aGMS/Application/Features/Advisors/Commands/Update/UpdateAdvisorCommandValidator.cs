using FluentValidation;

namespace Application.Features.Advisors.Commands.Update;

public class UpdateAdvisorCommandValidator : AbstractValidator<UpdateAdvisorCommand>
{
    public UpdateAdvisorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Department).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
    }
}