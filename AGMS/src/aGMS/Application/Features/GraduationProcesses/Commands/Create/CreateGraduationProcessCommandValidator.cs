using FluentValidation;

namespace Application.Features.GraduationProcesses.Commands.Create;

public class CreateGraduationProcessCommandValidator : AbstractValidator<CreateGraduationProcessCommand>
{
    public CreateGraduationProcessCommandValidator()
    {
        RuleFor(c => c.AdvisorApproved).NotEmpty();
        RuleFor(c => c.AdvisorApprovedDate).NotEmpty();
        RuleFor(c => c.DepartmentSecretaryApproved).NotEmpty();
        RuleFor(c => c.DepartmentSecretaryApprovedDate).NotEmpty();
        RuleFor(c => c.FacultyDeansOfficeApproved).NotEmpty();
        RuleFor(c => c.FacultyDeansOfficeApprovedDate).NotEmpty();
        RuleFor(c => c.StudentAffairsApproved).NotEmpty();
        RuleFor(c => c.StudentAffairsApprovedDate).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.GraduationListId).NotEmpty();
    }
}