using FluentValidation;

namespace Application.Features.FacultyDeansOffices.Commands.Create;

public class CreateFacultyDeansOfficeCommandValidator : AbstractValidator<CreateFacultyDeansOfficeCommand>
{
    public CreateFacultyDeansOfficeCommandValidator()
    {
        RuleFor(c => c.FacultyName).NotEmpty();
        RuleFor(c => c.StudentAffairId).NotEmpty();
        RuleFor(c => c.StudentAffair).NotEmpty();
    }
}