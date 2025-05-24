using NArchitecture.Core.Application.Responses;

namespace Application.Features.Transcripts.Commands.Delete;

public class DeletedTranscriptResponse : IResponse
{
    public Guid Id { get; set; }
}