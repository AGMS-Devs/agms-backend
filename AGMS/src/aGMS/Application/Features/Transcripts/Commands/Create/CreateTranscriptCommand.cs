using Application.Features.Transcripts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transcripts.Commands.Create;

public class CreateTranscriptCommand : IRequest<CreatedTranscriptResponse>
{
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
    public Guid StudentId { get; set; }
        public int RequiredCourseCount { get; set; }
    public int CompletedCourseCount { get; set; }

    public class CreateTranscriptCommandHandler : IRequestHandler<CreateTranscriptCommand, CreatedTranscriptResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly TranscriptBusinessRules _transcriptBusinessRules;

        public CreateTranscriptCommandHandler(IMapper mapper, ITranscriptRepository transcriptRepository,
                                         TranscriptBusinessRules transcriptBusinessRules)
        {
            _mapper = mapper;
            _transcriptRepository = transcriptRepository;
            _transcriptBusinessRules = transcriptBusinessRules;
        }

        public async Task<CreatedTranscriptResponse> Handle(CreateTranscriptCommand request, CancellationToken cancellationToken)
        {
            Transcript transcript = _mapper.Map<Transcript>(request);

            await _transcriptRepository.AddAsync(transcript);

            CreatedTranscriptResponse response = _mapper.Map<CreatedTranscriptResponse>(transcript);
            return response;
        }
    }
}