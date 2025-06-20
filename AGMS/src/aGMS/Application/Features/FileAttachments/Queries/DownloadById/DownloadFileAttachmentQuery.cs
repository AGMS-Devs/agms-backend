using Application.Features.FileAttachments.Constants;
using Application.Features.FileAttachments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FileAttachments.Constants.FileAttachmentsOperationClaims;
using Application.SubServices.StorageService;
using Microsoft.AspNetCore.Http;

namespace Application.Features.FileAttachments.Queries.Download;

public class DownloadFileAttachmentQuery : IRequest<DownloadFileAttachmentResponse>
{
    public Guid Id { get; set; }


    public class DownloadFileAttachmentQueryHandler : IRequestHandler<DownloadFileAttachmentQuery, DownloadFileAttachmentResponse>
    {
        private readonly IFileAttachmentRepository _fileAttachmentRepository;
        private readonly FileAttachmentBusinessRules _fileAttachmentBusinessRules;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public DownloadFileAttachmentQueryHandler(
            IFileAttachmentRepository fileAttachmentRepository,
            FileAttachmentBusinessRules fileAttachmentBusinessRules,
            IStorageService storageService,
            IMapper mapper)
        {
            _fileAttachmentRepository = fileAttachmentRepository;
            _fileAttachmentBusinessRules = fileAttachmentBusinessRules;
            _storageService = storageService;
            _mapper = mapper;
        }

        public async Task<DownloadFileAttachmentResponse> Handle(DownloadFileAttachmentQuery request, CancellationToken cancellationToken)
        {
            // Dosya mevcut mu kontrolü
            FileAttachment? fileAttachment = await _fileAttachmentRepository.GetAsync(
                predicate: fa => fa.Id == request.Id,
                cancellationToken: cancellationToken
            );

            await _fileAttachmentBusinessRules.FileAttachmentShouldExistWhenSelected(fileAttachment);


            using Stream fileStream = await _storageService.DownloadAsync(fileAttachment.FilePath);



            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();


            string contentType = GetContentType(fileAttachment.FileName);

            DownloadFileAttachmentResponse response = _mapper.Map<DownloadFileAttachmentResponse>(fileAttachment);
            
            response.FileName = fileAttachment.FileName;
            response.ContentType = contentType;
            response.FileData = fileData;
            
            return response;

        }
 

        private string GetContentType(string fileName)
        {
            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out string contentType))
            {
                contentType = "application/octet-stream"; 
            }
            return contentType;
        }
    }
}