using FluentValidation;

namespace Application.Features.GraduationProcesses.Commands.Delete;

public class DeleteGraduationProcessCommandValidator : AbstractValidator<DeleteGraduationProcessCommand>
{
    public DeleteGraduationProcessCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}