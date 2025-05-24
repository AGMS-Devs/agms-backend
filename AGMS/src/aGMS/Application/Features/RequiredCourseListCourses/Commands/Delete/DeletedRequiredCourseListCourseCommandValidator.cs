using FluentValidation;

namespace Application.Features.RequiredCourseListCourses.Commands.Delete;

public class DeleteRequiredCourseListCourseCommandValidator : AbstractValidator<DeleteRequiredCourseListCourseCommand>
{
    public DeleteRequiredCourseListCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}