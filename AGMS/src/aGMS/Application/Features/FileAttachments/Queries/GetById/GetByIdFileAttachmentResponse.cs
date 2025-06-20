using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Queries.GetById;

public class GetByIdFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public StorageType StorageType { get; set; }
    public long FileSize { get; set; }
    public FileType FileType { get; set; }
}