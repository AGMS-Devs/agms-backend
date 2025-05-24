using Application.Features.Ceremonies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Ceremonies.Queries.GetById;

public class GetByIdCeremonyQuery : IRequest<GetByIdCeremonyResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCeremonyQueryHandler : IRequestHandler<GetByIdCeremonyQuery, GetByIdCeremonyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly CeremonyBusinessRules _ceremonyBusinessRules;

        public GetByIdCeremonyQueryHandler(IMapper mapper, ICeremonyRepository ceremonyRepository, CeremonyBusinessRules ceremonyBusinessRules)
        {
            _mapper = mapper;
            _ceremonyRepository = ceremonyRepository;
            _ceremonyBusinessRules = ceremonyBusinessRules;
        }

        public async Task<GetByIdCeremonyResponse> Handle(GetByIdCeremonyQuery request, CancellationToken cancellationToken)
        {
            Ceremony? ceremony = await _ceremonyRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _ceremonyBusinessRules.CeremonyShouldExistWhenSelected(ceremony);

            GetByIdCeremonyResponse response = _mapper.Map<GetByIdCeremonyResponse>(ceremony);
            return response;
        }
    }
}