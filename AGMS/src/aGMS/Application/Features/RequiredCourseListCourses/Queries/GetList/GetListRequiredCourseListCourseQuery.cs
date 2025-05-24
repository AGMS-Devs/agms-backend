using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RequiredCourseListCourses.Queries.GetList;

public class GetListRequiredCourseListCourseQuery : IRequest<GetListResponse<GetListRequiredCourseListCourseListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRequiredCourseListCourseQueryHandler : IRequestHandler<GetListRequiredCourseListCourseQuery, GetListResponse<GetListRequiredCourseListCourseListItemDto>>
    {
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly IMapper _mapper;

        public GetListRequiredCourseListCourseQueryHandler(IRequiredCourseListCourseRepository requiredCourseListCourseRepository, IMapper mapper)
        {
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequiredCourseListCourseListItemDto>> Handle(GetListRequiredCourseListCourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RequiredCourseListCourse> requiredCourseListCourses = await _requiredCourseListCourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRequiredCourseListCourseListItemDto> response = _mapper.Map<GetListResponse<GetListRequiredCourseListCourseListItemDto>>(requiredCourseListCourses);
            return response;
        }
    }
}