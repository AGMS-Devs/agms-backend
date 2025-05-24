using FluentValidation;

namespace Application.Features.Departments.Commands.Update;

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DepartmentName).NotEmpty();
        RuleFor(c => c.DepartmentPhone).NotEmpty();
        RuleFor(c => c.FacultyId).NotEmpty();
    }
}