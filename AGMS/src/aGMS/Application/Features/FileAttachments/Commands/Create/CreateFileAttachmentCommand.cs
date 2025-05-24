using Application.Features.FileAttachments.Constants;
using Application.Features.FileAttachments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FileAttachments.Constants.FileAttachmentsOperationClaims;
using NArchitecture.Core.Application.Pipelines.Transaction;
using Microsoft.AspNetCore.Http;
using Application.SubServices.StorageService;
using System.Data.SqlTypes;
using Domain.Enums;


namespace Application.Features.FileAttachments.Commands.Create;

public class CreateFileAttachmentCommand : IRequest<CreatedFileAttachmentResponse>,  ITransactionalRequest
{

    public StorageType StorageType { get; set; }
    public Guid FileId { get; set; }  
    public FileType FileType { get; set; }
    public IFormFile File { get; set; }



    public class CreateFileAttachmentCommandHandler : IRequestHandler<CreateFileAttachmentCommand, CreatedFileAttachmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFileAttachmentRepository _fileAttachmentRepository;
        private readonly FileAttachmentBusinessRules _fileAttachmentBusinessRules;
        private readonly IStorage _storage;

        public CreateFileAttachmentCommandHandler(
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

        public async Task<CreatedFileAttachmentResponse> Handle(CreateFileAttachmentCommand request, CancellationToken cancellationToken)
        {
            await _fileAttachmentBusinessRules.FileTypeShouldBeValid(request.File.FileName, request.File.ContentType);

            string pathOrContainerName = request.FileType switch
            {
                FileType.Transcript => "transcripts",
                _ => "others"
            };

            var uploadedFileAttribute = await _storage.UploadAsync(pathOrContainerName, request.File);

            FileAttachment fileAttachment = _mapper.Map<FileAttachment>(request);
            fileAttachment.FilePath = uploadedFileAttribute.filePath;
            fileAttachment.FileName = uploadedFileAttribute.fileName;
            fileAttachment.FileSize = request.File.Length;
            fileAttachment.TranscriptId = request.FileId;
            fileAttachment.StorageType = StorageType.AzureStorage;
            fileAttachment.FileType = FileType.Transcript;



            await _fileAttachmentRepository.AddAsync(fileAttachment);

            CreatedFileAttachmentResponse response = _mapper.Map<CreatedFileAttachmentResponse>(fileAttachment);


            return response;
        }
    }
}