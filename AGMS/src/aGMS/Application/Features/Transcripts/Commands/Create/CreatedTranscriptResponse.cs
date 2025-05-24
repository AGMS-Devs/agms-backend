using NArchitecture.Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Transcripts.Commands.Create;

public class CreatedTranscriptResponse : IResponse
{
    public Guid Id { get; set; }
    public string StudentIdentityNumber { get; set; }
    public string TranscriptFileName { get; set; }
    public decimal TranscriptGpa { get; set; }
    public DateTime TranscriptDate { get; set; }
    public string TranscriptDescription { get; set; }
    public string DepartmentGraduationRank { get; set; }
    public string FacultyGraduationRank { get; set; }
    public string UniversityGraduationRank { get; set; }
    public string GraduationYear { get; set; }
    public int TotalTakenCredit { get; set; }
    public int TotalRequiredCredit { get; set; }
    public int CompletedCredit { get; set; }
    public int RemainingCredit { get; set; }
    public FileAttachment FileAttachment { get; set; }
    public Guid StudentId { get; set; }
        public int RequiredCourseCount { get; set; }
    public int CompletedCourseCount { get; set; }
}