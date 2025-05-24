using NArchitecture.Core.Application.Responses;

namespace Application.Features.Transcripts.Commands.UpdateTranscriptCalculations;

public class UpdatedTranscriptCalculationsResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public int TotalTakenCredit { get; set; }
    public int TotalRequiredCredit { get; set; }
    public int CompletedCredit { get; set; }
    public int RemainingCredit { get; set; }
    public int RequiredCourseCount { get; set; }
    public int CompletedCourseCount { get; set; }
    public decimal TranscriptGpa { get; set; }
    public DateTime UpdatedDate { get; set; }
} 