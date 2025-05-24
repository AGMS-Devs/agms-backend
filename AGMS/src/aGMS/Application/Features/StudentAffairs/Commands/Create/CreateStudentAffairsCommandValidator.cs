using FluentValidation;

namespace Application.Features.StudentAffairs.Commands.Create;

public class CreateStudentAffairsCommandValidator : AbstractValidator<CreateStudentAffairsCommand>
{
    public CreateStudentAffairsCommandValidator()
    {
        RuleFor(c => c.OfficeName).NotEmpty();
    }
}