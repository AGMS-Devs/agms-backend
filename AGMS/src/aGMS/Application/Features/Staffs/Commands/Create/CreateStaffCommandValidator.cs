using FluentValidation;

namespace Application.Features.Staffs.Commands.Create;

public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
{
    public CreateStaffCommandValidator()
    {
        RuleFor(c => c.StaffPhone).NotEmpty();
        RuleFor(c => c.StaffRole).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
        RuleFor(c => c.FacultyId).NotEmpty();
    }
}