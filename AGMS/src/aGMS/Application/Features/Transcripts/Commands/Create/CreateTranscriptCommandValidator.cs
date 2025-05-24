using FluentValidation;

namespace Application.Features.Transcripts.Commands.Create;

public class CreateTranscriptCommandValidator : AbstractValidator<CreateTranscriptCommand>
{
    public CreateTranscriptCommandValidator()
    {
        RuleFor(c => c.TranscriptFileName).NotEmpty();
        RuleFor(c => c.TranscriptGpa).NotEmpty();
        RuleFor(c => c.TranscriptDate).NotEmpty();
        RuleFor(c => c.StudentIdentityNumber).NotEmpty();
        RuleFor(c => c.TranscriptDescription).NotEmpty();
        RuleFor(c => c.DepartmentGraduationRank).NotEmpty();
        RuleFor(c => c.FacultyGraduationRank).NotEmpty();
        RuleFor(c => c.UniversityGraduationRank).NotEmpty();
        RuleFor(c => c.GraduationYear).NotEmpty();
        RuleFor(c => c.TotalTakenCredit).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.RequiredCourseCount).NotEmpty();
        RuleFor(c => c.CompletedCourseCount).NotEmpty();
    }
}