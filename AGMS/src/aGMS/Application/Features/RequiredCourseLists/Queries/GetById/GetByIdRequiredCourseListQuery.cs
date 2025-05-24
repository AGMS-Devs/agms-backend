using Application.Features.RequiredCourseLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RequiredCourseLists.Queries.GetById;

public class GetByIdRequiredCourseListQuery : IRequest<GetByIdRequiredCourseListResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRequiredCourseListQueryHandler : IRequestHandler<GetByIdRequiredCourseListQuery, GetByIdRequiredCourseListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly RequiredCourseListBusinessRules _requiredCourseListBusinessRules;

        public GetByIdRequiredCourseListQueryHandler(
            IMapper mapper, 
            IRequiredCourseListRepository requiredCourseListRepository,
            IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
            RequiredCourseListBusinessRules requiredCourseListBusinessRules)
        {
            _mapper = mapper;
            _requiredCourseListRepository = requiredCourseListRepository;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _requiredCourseListBusinessRules = requiredCourseListBusinessRules;
        }

        public async Task<GetByIdRequiredCourseListResponse> Handle(GetByIdRequiredCourseListQuery request, CancellationToken cancellationToken)
        {
            // Önce RequiredCourseList'i al
            RequiredCourseList? requiredCourseList = await _requiredCourseListRepository.GetAsync(
                predicate: rcl => rcl.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _requiredCourseListBusinessRules.RequiredCourseListShouldExistWhenSelected(requiredCourseList);

            // Sonra Course'ları ayrı sorgu ile al
            var requiredCourseListCourses = await _requiredCourseListCourseRepository.GetListAsync(
                predicate: rclc => rclc.RequiredCourseListId == request.Id,
                include: query => query.Include(rclc => rclc.Course),
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            // Course'ları RequiredCourseList'e manuel yükle
            requiredCourseList.Courses = requiredCourseListCourses.Items
                .Select(rclc => rclc.Course)
                .ToHashSet();

            GetByIdRequiredCourseListResponse response = _mapper.Map<GetByIdRequiredCourseListResponse>(requiredCourseList);
            return response;
        }
    }
}