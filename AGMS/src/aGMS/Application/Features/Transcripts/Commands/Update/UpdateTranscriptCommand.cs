using Application.Features.Transcripts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transcripts.Commands.Update;

public class UpdateTranscriptCommand : IRequest<UpdatedTranscriptResponse>
{
    public Guid Id { get; set; }
    public string StudentIdentityNumber { get; set; }
    public string TranscriptFileName { get; set; }
    public decimal TranscriptGpa { get; set; }
    public DateTime TranscriptDate { get; set; }
    public string TranscriptDescription { get; set; }
    public string DepartmentGraduationRank { get; set; }
    public string FacultyGraduationRank { get; set; }
    public string UniversityGraduationRank { get; set; }
    public string GraduationYear { get; set; }
    public int TotalTakenCredit { get; set; }
    public int TotalRequiredCredit { get; set; }
    public int CompletedCredit { get; set; }
    public int RemainingCredit { get; set; }
        public int RequiredCourseCount { get; set; }
    public int CompletedCourseCount { get; set; }
    public Guid StudentId { get; set; }

    public class UpdateTranscriptCommandHandler : IRequestHandler<UpdateTranscriptCommand, UpdatedTranscriptResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly TranscriptBusinessRules _transcriptBusinessRules;

        public UpdateTranscriptCommandHandler(IMapper mapper, ITranscriptRepository transcriptRepository,
                                         TranscriptBusinessRules transcriptBusinessRules)
        {
            _mapper = mapper;
            _transcriptRepository = transcriptRepository;
            _transcriptBusinessRules = transcriptBusinessRules;
        }

        public async Task<UpdatedTranscriptResponse> Handle(UpdateTranscriptCommand request, CancellationToken cancellationToken)
        {
            Transcript? transcript = await _transcriptRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transcriptBusinessRules.TranscriptShouldExistWhenSelected(transcript);
            transcript = _mapper.Map(request, transcript);

            await _transcriptRepository.UpdateAsync(transcript!);

            UpdatedTranscriptResponse response = _mapper.Map<UpdatedTranscriptResponse>(transcript);
            return response;
        }
    }
}