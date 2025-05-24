using FluentValidation;

namespace Application.Features.StudentAffairs.Commands.Delete;

public class DeleteStudentAffairsCommandValidator : AbstractValidator<DeleteStudentAffairsCommand>
{
    public DeleteStudentAffairsCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}