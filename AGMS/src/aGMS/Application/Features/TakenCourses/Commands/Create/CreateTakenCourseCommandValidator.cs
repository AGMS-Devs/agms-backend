using FluentValidation;

namespace Application.Features.TakenCourses.Commands.Create;

public class CreateTakenCourseCommandValidator : AbstractValidator<CreateTakenCourseCommand>
{
    public CreateTakenCourseCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.Grade).NotEmpty();
        RuleFor(c => c.TakenDate).NotEmpty();
    }
}