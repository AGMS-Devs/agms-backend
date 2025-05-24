using FluentValidation;

namespace Application.Features.FacultyDeansOffices.Commands.Update;

public class UpdateFacultyDeansOfficeCommandValidator : AbstractValidator<UpdateFacultyDeansOfficeCommand>
{
    public UpdateFacultyDeansOfficeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FacultyName).NotEmpty();
        RuleFor(c => c.StudentAffairId).NotEmpty();
        RuleFor(c => c.StudentAffair).NotEmpty();
    }
}