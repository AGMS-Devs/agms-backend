using FluentValidation;

namespace Application.Features.Staffs.Commands.Update;

public class UpdateStaffCommandValidator : AbstractValidator<UpdateStaffCommand>
{
    public UpdateStaffCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StaffPhone).NotEmpty();
        RuleFor(c => c.StaffRole).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
        RuleFor(c => c.FacultyId).NotEmpty();
    }
}