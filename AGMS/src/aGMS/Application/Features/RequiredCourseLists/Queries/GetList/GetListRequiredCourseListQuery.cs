using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RequiredCourseLists.Queries.GetList;

public class GetListRequiredCourseListQuery : IRequest<GetListResponse<GetListRequiredCourseListListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRequiredCourseListQueryHandler : IRequestHandler<GetListRequiredCourseListQuery, GetListResponse<GetListRequiredCourseListListItemDto>>
    {
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly IMapper _mapper;

        public GetListRequiredCourseListQueryHandler(
            IRequiredCourseListRepository requiredCourseListRepository,
            IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
            IMapper mapper)
        {
            _requiredCourseListRepository = requiredCourseListRepository;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequiredCourseListListItemDto>> Handle(GetListRequiredCourseListQuery request, CancellationToken cancellationToken)
        {
            // Önce RequiredCourseList'leri al (Course'lar olmadan)
            IPaginate<RequiredCourseList> requiredCourseLists = await _requiredCourseListRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            // Her RequiredCourseList için Course'ları ayrı yükle
            foreach (var requiredCourseList in requiredCourseLists.Items)
            {
                var requiredCourseListCourses = await _requiredCourseListCourseRepository.GetListAsync(
                    predicate: rclc => rclc.RequiredCourseListId == requiredCourseList.Id,
                    include: query => query.Include(rclc => rclc.Course),
                    size: int.MaxValue,
                    cancellationToken: cancellationToken
                );

                requiredCourseList.Courses = requiredCourseListCourses.Items
                    .Select(rclc => rclc.Course)
                    .ToHashSet();
            }

            GetListResponse<GetListRequiredCourseListListItemDto> response = _mapper.Map<GetListResponse<GetListRequiredCourseListListItemDto>>(requiredCourseLists);
            return response;
        }
    }
}