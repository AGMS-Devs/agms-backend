using FluentValidation;

namespace Application.Features.RequiredCourseListCourses.Commands.Create;

public class CreateRequiredCourseListCourseCommandValidator : AbstractValidator<CreateRequiredCourseListCourseCommand>
{
    public CreateRequiredCourseListCourseCommandValidator()
    {
        RuleFor(c => c.RequiredCourseListId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}