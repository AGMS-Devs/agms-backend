using FluentValidation;

namespace Application.Features.RequiredCourseLists.Commands.Delete;

public class DeleteRequiredCourseListCommandValidator : AbstractValidator<DeleteRequiredCourseListCommand>
{
    public DeleteRequiredCourseListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}