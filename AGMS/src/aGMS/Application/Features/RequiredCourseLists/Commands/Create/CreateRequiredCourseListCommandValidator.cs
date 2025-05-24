using FluentValidation;

namespace Application.Features.RequiredCourseLists.Commands.Create;

public class CreateRequiredCourseListCommandValidator : AbstractValidator<CreateRequiredCourseListCommand>
{
    public CreateRequiredCourseListCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}