using Application.Features.FileAttachments.Constants;
using Application.Features.FileAttachments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Transaction;
using Microsoft.AspNetCore.Http;
using Application.SubServices.StorageService;
using static Application.Features.FileAttachments.Constants.FileAttachmentsOperationClaims;

namespace Application.Features.FileAttachments.Commands.Update;

public class UpdateFileAttachmentCommand : IRequest<UpdatedFileAttachmentResponse>, ITransactionalRequest
{
    public Guid Id { get; set; }
    public StorageType StorageType { get; set; }
    public Guid FileId { get; set; }  
    public FileType FileType { get; set; }
    public IFormFile? File { get; set; }  // Opsiyonel - dosya değiştirilmek istenirse

    public class UpdateFileAttachmentCommandHandler : IRequestHandler<UpdateFileAttachmentCommand, UpdatedFileAttachmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFileAttachmentRepository _fileAttachmentRepository;
        private readonly FileAttachmentBusinessRules _fileAttachmentBusinessRules;
        private readonly IStorage _storage;

        public UpdateFileAttachmentCommandHandler(
            IMapper mapper, 
            IFileAttachmentRepository fileAttachmentRepository,
            FileAttachmentBusinessRules fileAttachmentBusinessRules,
            IStorage storage)
        {
            _mapper = mapper;
            _fileAttachmentRepository = fileAttachmentRepository;
            _fileAttachmentBusinessRules = fileAttachmentBusinessRules;
            _storage = storage;
        }

        public async Task<UpdatedFileAttachmentResponse> Handle(UpdateFileAttachmentCommand request, CancellationToken cancellationToken)
        {
            FileAttachment? fileAttachment = await _fileAttachmentRepository.GetAsync(
                predicate: fa => fa.Id == request.Id, 
                cancellationToken: cancellationToken);
            
            await _fileAttachmentBusinessRules.FileAttachmentShouldExistWhenSelected(fileAttachment);

            // Eğer yeni dosya yüklenmişse
            if (request.File != null)
            {
                await _fileAttachmentBusinessRules.FileTypeShouldBeValid(request.File.FileName, request.File.ContentType);

                // Eski dosyayı sil
                if (!string.IsNullOrEmpty(fileAttachment!.FilePath))
                {
                    await _storage.DeleteAsync(fileAttachment.FilePath);
                }

                // Yeni dosyayı yükle
                string pathOrContainerName = request.FileType switch
                {
                    FileType.Transcript => "transcripts",
                    _ => "others"
                };

                var uploadedFileAttribute = await _storage.UploadAsync(pathOrContainerName, request.File);

                // FileAttachment'ı güncelle
                fileAttachment.FilePath = uploadedFileAttribute.filePath;
                fileAttachment.FileName = uploadedFileAttribute.fileName;
                fileAttachment.FileSize = request.File.Length;
            }

            // Diğer özellikleri güncelle
            fileAttachment!.StorageType = request.StorageType;
            fileAttachment.FileType = request.FileType;
            fileAttachment.TranscriptId = request.FileId;
            fileAttachment.UpdatedDate = DateTime.UtcNow;

            await _fileAttachmentRepository.UpdateAsync(fileAttachment);

            UpdatedFileAttachmentResponse response = _mapper.Map<UpdatedFileAttachmentResponse>(fileAttachment);
            return response;
        }
    }
}