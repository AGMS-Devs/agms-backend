using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transcripts.Queries.GetList;

public class GetListTranscriptQuery : IRequest<GetListResponse<GetListTranscriptListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTranscriptQueryHandler : IRequestHandler<GetListTranscriptQuery, GetListResponse<GetListTranscriptListItemDto>>
    {
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly IMapper _mapper;

        public GetListTranscriptQueryHandler(ITranscriptRepository transcriptRepository, IMapper mapper)
        {
            _transcriptRepository = transcriptRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTranscriptListItemDto>> Handle(GetListTranscriptQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Transcript> transcripts = await _transcriptRepository.GetListAsync(
                include: t => t.Include(x => x.FileAttachment),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTranscriptListItemDto> response = _mapper.Map<GetListResponse<GetListTranscriptListItemDto>>(transcripts);
            return response;
        }
    }
}