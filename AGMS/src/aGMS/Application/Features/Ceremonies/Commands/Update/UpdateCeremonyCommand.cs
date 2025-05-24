using Application.Features.Ceremonies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Ceremonies.Commands.Update;

public class UpdateCeremonyCommand : IRequest<UpdatedCeremonyResponse>
{
    public Guid Id { get; set; }
    public DateTime CeremonyDate { get; set; }
    public string CeremonyLocation { get; set; }
    public string CeremonyDescription { get; set; }
    public CeremonyStatus CeremonyStatus { get; set; }
    public string AcademicYear { get; set; }
    public Guid StudentAffairsId { get; set; }
    public StudentAffair StudentAffair { get; set; }

    public class UpdateCeremonyCommandHandler : IRequestHandler<UpdateCeremonyCommand, UpdatedCeremonyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly CeremonyBusinessRules _ceremonyBusinessRules;

        public UpdateCeremonyCommandHandler(IMapper mapper, ICeremonyRepository ceremonyRepository,
                                         CeremonyBusinessRules ceremonyBusinessRules)
        {
            _mapper = mapper;
            _ceremonyRepository = ceremonyRepository;
            _ceremonyBusinessRules = ceremonyBusinessRules;
        }

        public async Task<UpdatedCeremonyResponse> Handle(UpdateCeremonyCommand request, CancellationToken cancellationToken)
        {
            Ceremony? ceremony = await _ceremonyRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _ceremonyBusinessRules.CeremonyShouldExistWhenSelected(ceremony);
            ceremony = _mapper.Map(request, ceremony);

            await _ceremonyRepository.UpdateAsync(ceremony!);

            UpdatedCeremonyResponse response = _mapper.Map<UpdatedCeremonyResponse>(ceremony);
            return response;
        }
    }
}