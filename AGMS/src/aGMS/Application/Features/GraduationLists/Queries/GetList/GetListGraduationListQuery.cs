using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.GraduationLists.Queries.GetList;

public class GetListGraduationListQuery : IRequest<GetListResponse<GetListGraduationListListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGraduationListQueryHandler : IRequestHandler<GetListGraduationListQuery, GetListResponse<GetListGraduationListListItemDto>>
    {
        private readonly IGraduationListRepository _graduationListRepository;
        private readonly IMapper _mapper;

        public GetListGraduationListQueryHandler(IGraduationListRepository graduationListRepository, IMapper mapper)
        {
            _graduationListRepository = graduationListRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGraduationListListItemDto>> Handle(GetListGraduationListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GraduationList> graduationLists = await _graduationListRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGraduationListListItemDto> response = _mapper.Map<GetListResponse<GetListGraduationListListItemDto>>(graduationLists);
            return response;
        }
    }
}