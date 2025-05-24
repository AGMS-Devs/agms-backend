using Application.Features.Rectorates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rectorates.Queries.GetById;

public class GetByIdRectorateQuery : IRequest<GetByIdRectorateResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRectorateQueryHandler : IRequestHandler<GetByIdRectorateQuery, GetByIdRectorateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRectorateRepository _rectorateRepository;
        private readonly RectorateBusinessRules _rectorateBusinessRules;

        public GetByIdRectorateQueryHandler(IMapper mapper, IRectorateRepository rectorateRepository, RectorateBusinessRules rectorateBusinessRules)
        {
            _mapper = mapper;
            _rectorateRepository = rectorateRepository;
            _rectorateBusinessRules = rectorateBusinessRules;
        }

        public async Task<GetByIdRectorateResponse> Handle(GetByIdRectorateQuery request, CancellationToken cancellationToken)
        {
            Rectorate? rectorate = await _rectorateRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rectorateBusinessRules.RectorateShouldExistWhenSelected(rectorate);

            GetByIdRectorateResponse response = _mapper.Map<GetByIdRectorateResponse>(rectorate);
            return response;
        }
    }
}