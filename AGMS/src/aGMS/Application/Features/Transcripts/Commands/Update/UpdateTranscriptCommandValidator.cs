using FluentValidation;

namespace Application.Features.Transcripts.Commands.Update;

public class UpdateTranscriptCommandValidator : AbstractValidator<UpdateTranscriptCommand>
{
    public UpdateTranscriptCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentIdentityNumber).NotEmpty();
        RuleFor(c => c.TranscriptFileName).NotEmpty();
        RuleFor(c => c.TranscriptGpa).NotEmpty();
        RuleFor(c => c.TranscriptDescription).NotEmpty();
        RuleFor(c => c.DepartmentGraduationRank).NotEmpty();
        RuleFor(c => c.FacultyGraduationRank).NotEmpty();
        RuleFor(c => c.UniversityGraduationRank).NotEmpty();
        RuleFor(c => c.GraduationYear).NotEmpty();
        RuleFor(c => c.TotalTakenCredit).NotEmpty();
        RuleFor(c => c.TotalRequiredCredit).NotEmpty();
        RuleFor(c => c.TranscriptDate).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.RequiredCourseCount).NotEmpty();
        RuleFor(c => c.CompletedCourseCount).NotEmpty();
    }
}