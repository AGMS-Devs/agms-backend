using FluentValidation;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentNumber).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
        RuleFor(c => c.EnrollDate).NotEmpty();
        RuleFor(c => c.StudentStatus).NotEmpty();
        RuleFor(c => c.GraduationStatus).NotEmpty();
        RuleFor(c => c.AssignedAdvisorId).NotEmpty();   
        RuleFor(c => c.RequiredCourseListId).NotEmpty();
    }
}