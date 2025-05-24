using Application.Features.Transcripts.Constants;
using Application.Features.Transcripts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transcripts.Commands.Delete;

public class DeleteTranscriptCommand : IRequest<DeletedTranscriptResponse>
{
    public Guid Id { get; set; }

    public class DeleteTranscriptCommandHandler : IRequestHandler<DeleteTranscriptCommand, DeletedTranscriptResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly TranscriptBusinessRules _transcriptBusinessRules;

        public DeleteTranscriptCommandHandler(IMapper mapper, ITranscriptRepository transcriptRepository,
                                         TranscriptBusinessRules transcriptBusinessRules)
        {
            _mapper = mapper;
            _transcriptRepository = transcriptRepository;
            _transcriptBusinessRules = transcriptBusinessRules;
        }

        public async Task<DeletedTranscriptResponse> Handle(DeleteTranscriptCommand request, CancellationToken cancellationToken)
        {
            Transcript? transcript = await _transcriptRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transcriptBusinessRules.TranscriptShouldExistWhenSelected(transcript);

            await _transcriptRepository.DeleteAsync(transcript!);

            DeletedTranscriptResponse response = _mapper.Map<DeletedTranscriptResponse>(transcript);
            return response;
        }
    }
}