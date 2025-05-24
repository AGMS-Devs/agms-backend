using FluentValidation;

namespace Application.Features.TakenCourses.Commands.Delete;

public class DeleteTakenCourseCommandValidator : AbstractValidator<DeleteTakenCourseCommand>
{
    public DeleteTakenCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}