using FluentValidation;

namespace Application.Features.RequiredCourseListCourses.Commands.Update;

public class UpdateRequiredCourseListCourseCommandValidator : AbstractValidator<UpdateRequiredCourseListCourseCommand>
{
    public UpdateRequiredCourseListCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RequiredCourseListId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}