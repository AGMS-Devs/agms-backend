using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Commands.Create;

public class CreatedFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public StorageType StorageType { get; set; }
    public FileType FileType { get; set; }
    public long FileSize { get; set; }
    public Guid TranscriptId { get; set; }

}