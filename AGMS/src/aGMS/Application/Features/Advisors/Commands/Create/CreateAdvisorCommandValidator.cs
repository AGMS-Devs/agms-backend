using FluentValidation;

namespace Application.Features.Advisors.Commands.Create;

public class CreateAdvisorCommandValidator : AbstractValidator<CreateAdvisorCommand>
{
    public CreateAdvisorCommandValidator()
    {

        RuleFor(c => c.DepartmentId).NotEmpty();
    }
}