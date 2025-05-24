using FluentValidation;

namespace Application.Features.RequiredCourseLists.Commands.Update;

public class UpdateRequiredCourseListCommandValidator : AbstractValidator<UpdateRequiredCourseListCommand>
{
    public UpdateRequiredCourseListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}