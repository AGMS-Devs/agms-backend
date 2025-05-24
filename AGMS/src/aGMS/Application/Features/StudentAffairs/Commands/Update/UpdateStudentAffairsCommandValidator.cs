using FluentValidation;

namespace Application.Features.StudentAffairs.Commands.Update;

public class UpdateStudentAffairsCommandValidator : AbstractValidator<UpdateStudentAffairsCommand>
{
    public UpdateStudentAffairsCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OfficeName).NotEmpty();
    }
}