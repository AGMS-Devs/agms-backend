
using System;
using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class FileAttachment : Entity<Guid>
{
    public string FileName { get; set; } = string.Empty;   
    public string FilePath { get; set; } = string.Empty;   
    public StorageType StorageType { get; set; }
    public long FileSize { get; set; }                      
    public FileType FileType { get; set; }
    public Guid TranscriptId { get; set; }
    public Transcript Transcript { get; set; }
    public FileAttachment()
    {

    }

    public FileAttachment(string fileName, string filePath, StorageType storageType, FileType fileType, Guid transcriptId)
    {
        Id = Guid.NewGuid();
        FileName = fileName;
        FilePath = filePath;
        StorageType = storageType;
        FileType = fileType;
        TranscriptId = transcriptId;
        CreatedDate = DateTime.UtcNow;
    }
    
} 