using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Rectorates.Queries.GetList;

public class GetListRectorateQuery : IRequest<GetListResponse<GetListRectorateListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRectorateQueryHandler : IRequestHandler<GetListRectorateQuery, GetListResponse<GetListRectorateListItemDto>>
    {
        private readonly IRectorateRepository _rectorateRepository;
        private readonly IMapper _mapper;

        public GetListRectorateQueryHandler(IRectorateRepository rectorateRepository, IMapper mapper)
        {
            _rectorateRepository = rectorateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRectorateListItemDto>> Handle(GetListRectorateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Rectorate> rectorates = await _rectorateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRectorateListItemDto> response = _mapper.Map<GetListResponse<GetListRectorateListItemDto>>(rectorates);
            return response;
        }
    }
}