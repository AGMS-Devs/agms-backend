using Application.Features.Ceremonies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Ceremonies.Commands.Create;

public class CreateCeremonyCommand : IRequest<CreatedCeremonyResponse>
{
    public DateTime CeremonyDate { get; set; }
    public string CeremonyLocation { get; set; }
    public string CeremonyDescription { get; set; }
    public CeremonyStatus CeremonyStatus { get; set; }
    public string AcademicYear { get; set; }
    public Guid StudentAffairsId { get; set; }
    public StudentAffair StudentAffair { get; set; }

    public class CreateCeremonyCommandHandler : IRequestHandler<CreateCeremonyCommand, CreatedCeremonyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly CeremonyBusinessRules _ceremonyBusinessRules;

        public CreateCeremonyCommandHandler(IMapper mapper, ICeremonyRepository ceremonyRepository,
                                         CeremonyBusinessRules ceremonyBusinessRules)
        {
            _mapper = mapper;
            _ceremonyRepository = ceremonyRepository;
            _ceremonyBusinessRules = ceremonyBusinessRules;
        }

        public async Task<CreatedCeremonyResponse> Handle(CreateCeremonyCommand request, CancellationToken cancellationToken)
        {
            Ceremony ceremony = _mapper.Map<Ceremony>(request);

            await _ceremonyRepository.AddAsync(ceremony);

            CreatedCeremonyResponse response = _mapper.Map<CreatedCeremonyResponse>(ceremony);
            return response;
        }
    }
}