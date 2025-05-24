using FluentValidation;

namespace Application.Features.TakenCourses.Commands.Update;

public class UpdateTakenCourseCommandValidator : AbstractValidator<UpdateTakenCourseCommand>
{
    public UpdateTakenCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.Grade).NotEmpty();
        RuleFor(c => c.TakenDate).NotEmpty();
    }
}