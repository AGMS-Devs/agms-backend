using FluentValidation;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c => c.CourseName).NotEmpty();
        RuleFor(c => c.CourseCode).NotEmpty();
        RuleFor(c => c.TeoricHours).NotEmpty();
        RuleFor(c => c.PracticalHours).NotEmpty();
        RuleFor(c => c.ECTS).NotEmpty();
        RuleFor(c => c.HalfYear).NotEmpty();
        RuleFor(c => c.CourseDescription).NotEmpty();
        RuleFor(c => c.CourseCredit).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
        RuleFor(c => c.FacultyId).NotEmpty();
    }
}