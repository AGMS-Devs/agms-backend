using FluentValidation;

namespace Application.Features.FacultyDeansOffices.Commands.Delete;

public class DeleteFacultyDeansOfficeCommandValidator : AbstractValidator<DeleteFacultyDeansOfficeCommand>
{
    public DeleteFacultyDeansOfficeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}