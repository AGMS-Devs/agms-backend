using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TakenCourses.Queries.GetList;

public class GetListTakenCourseQuery : IRequest<GetListResponse<GetListTakenCourseListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTakenCourseQueryHandler : IRequestHandler<GetListTakenCourseQuery, GetListResponse<GetListTakenCourseListItemDto>>
    {
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly IMapper _mapper;

        public GetListTakenCourseQueryHandler(ITakenCourseRepository takenCourseRepository, IMapper mapper)
        {
            _takenCourseRepository = takenCourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTakenCourseListItemDto>> Handle(GetListTakenCourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TakenCourse> takenCourses = await _takenCourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTakenCourseListItemDto> response = _mapper.Map<GetListResponse<GetListTakenCourseListItemDto>>(takenCourses);
            return response;
        }
    }
}