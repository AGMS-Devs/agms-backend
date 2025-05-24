using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.FileAttachments.Queries.GetList;

public class GetListFileAttachmentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public StorageType StorageType { get; set; }
    public long FileSize { get; set; }
    public FileType FileType { get; set; }
}