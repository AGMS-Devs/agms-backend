using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentAffairs.Queries.GetList;

public class GetListStudentAffairsQuery : IRequest<GetListResponse<GetListStudentAffairsListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentAffairsQueryHandler : IRequestHandler<GetListStudentAffairsQuery, GetListResponse<GetListStudentAffairsListItemDto>>
    {
        private readonly IStudentAffairRepository _studentAffairRepository;
        private readonly IMapper _mapper;

        public GetListStudentAffairsQueryHandler(IStudentAffairRepository studentAffairRepository, IMapper mapper)
        {
            _studentAffairRepository = studentAffairRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentAffairsListItemDto>> Handle(GetListStudentAffairsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentAffair> studentAffairs = await _studentAffairRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentAffairsListItemDto> response = _mapper.Map<GetListResponse<GetListStudentAffairsListItemDto>>(studentAffairs);
            return response;
        }
    }
}