using FluentValidation;

namespace Application.Features.Advisors.Commands.Delete;

public class DeleteAdvisorCommandValidator : AbstractValidator<DeleteAdvisorCommand>
{
    public DeleteAdvisorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}