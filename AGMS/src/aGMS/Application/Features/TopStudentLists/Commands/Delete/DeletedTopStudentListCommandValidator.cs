using FluentValidation;

namespace Application.Features.TopStudentLists.Commands.Delete;

public class DeleteTopStudentListCommandValidator : AbstractValidator<DeleteTopStudentListCommand>
{
    public DeleteTopStudentListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}