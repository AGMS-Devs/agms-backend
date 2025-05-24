using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Ceremonies.Queries.GetList;

public class GetListCeremonyQuery : IRequest<GetListResponse<GetListCeremonyListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCeremonyQueryHandler : IRequestHandler<GetListCeremonyQuery, GetListResponse<GetListCeremonyListItemDto>>
    {
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly IMapper _mapper;

        public GetListCeremonyQueryHandler(ICeremonyRepository ceremonyRepository, IMapper mapper)
        {
            _ceremonyRepository = ceremonyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCeremonyListItemDto>> Handle(GetListCeremonyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ceremony> ceremonies = await _ceremonyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query.Include(c => c.StudentUsers).Include(c => c.StudentAffair),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCeremonyListItemDto> response = _mapper.Map<GetListResponse<GetListCeremonyListItemDto>>(ceremonies);
            return response;
        }
    }
}