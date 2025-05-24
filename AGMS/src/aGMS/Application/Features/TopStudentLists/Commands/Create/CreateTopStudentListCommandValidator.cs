using FluentValidation;
using Domain.Enums;

namespace Application.Features.TopStudentLists.Commands.Create;

public class CreateTopStudentListCommandValidator : AbstractValidator<CreateTopStudentListCommand>
{
    public CreateTopStudentListCommandValidator()
    {
        RuleFor(c => c.TopStudentListType).IsInEnum();      
        RuleFor(c => c.StudentAffairsStaffId).NotEmpty();
        RuleFor(c => c.RectorateStaffId).NotEmpty();
        
        // Type'a göre gerekli field kontrolü
        RuleFor(c => c.DepartmentId)
            .NotEmpty()
            .When(c => c.TopStudentListType == TopStudentListType.Department)
            .WithMessage("DepartmentId is required when TopStudentListType is Department.");
            
        RuleFor(c => c.FacultyId)
            .NotEmpty()
            .When(c => c.TopStudentListType == TopStudentListType.Faculty)
            .WithMessage("FacultyId is required when TopStudentListType is Faculty.");
    }
}