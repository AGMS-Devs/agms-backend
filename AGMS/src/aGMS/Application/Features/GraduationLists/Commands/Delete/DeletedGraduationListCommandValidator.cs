using FluentValidation;

namespace Application.Features.GraduationLists.Commands.Delete;

public class DeleteGraduationListCommandValidator : AbstractValidator<DeleteGraduationListCommand>
{
    public DeleteGraduationListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}