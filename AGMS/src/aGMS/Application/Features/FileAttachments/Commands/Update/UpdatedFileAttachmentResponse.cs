using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Commands.Update;

using Domain.Enums;

public class UpdatedFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public StorageType StorageType { get; set; }
    public long FileSize { get; set; }
    public FileType FileType { get; set; }
    public Guid TranscriptId { get; set; }
}

