using FluentValidation;

namespace Application.Features.TopStudentLists.Commands.Update;

public class UpdateTopStudentListCommandValidator : AbstractValidator<UpdateTopStudentListCommand>
{
    public UpdateTopStudentListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TopStudentListType).NotEmpty();
        RuleFor(c => c.StudentAffairsApproval).NotEmpty();
        RuleFor(c => c.StudentAffairsStaffId).NotEmpty();
        RuleFor(c => c.RectorateApproval).NotEmpty();
        RuleFor(c => c.RectorateStaffId).NotEmpty();
        RuleFor(c => c.SendRectorate).NotEmpty();
    }
}