using Application.Features.Transcripts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transcripts.Queries.GetById;

public class GetByIdTranscriptQuery : IRequest<GetByIdTranscriptResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTranscriptQueryHandler : IRequestHandler<GetByIdTranscriptQuery, GetByIdTranscriptResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly TranscriptBusinessRules _transcriptBusinessRules;

        public GetByIdTranscriptQueryHandler(IMapper mapper, ITranscriptRepository transcriptRepository, TranscriptBusinessRules transcriptBusinessRules)
        {
            _mapper = mapper;
            _transcriptRepository = transcriptRepository;
            _transcriptBusinessRules = transcriptBusinessRules;
        }

        public async Task<GetByIdTranscriptResponse> Handle(GetByIdTranscriptQuery request, CancellationToken cancellationToken)
        {
            Transcript? transcript = await _transcriptRepository.GetAsync(
                predicate: t => t.Id == request.Id, 
                include: t => t.Include(x => x.FileAttachment),
                cancellationToken: cancellationToken);
            await _transcriptBusinessRules.TranscriptShouldExistWhenSelected(transcript);

            GetByIdTranscriptResponse response = _mapper.Map<GetByIdTranscriptResponse>(transcript);
            return response;
        }
    }
}