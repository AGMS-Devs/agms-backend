using FluentValidation;

namespace Application.Features.Departments.Commands.Create;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(c => c.DepartmentName).NotEmpty();
        RuleFor(c => c.DepartmentPhone).NotEmpty();
        RuleFor(c => c.FacultyId).NotEmpty();
    }
}