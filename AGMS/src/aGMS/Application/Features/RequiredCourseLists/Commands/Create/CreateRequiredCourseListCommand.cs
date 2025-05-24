using Application.Features.RequiredCourseLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RequiredCourseLists.Commands.Create;

public class CreateRequiredCourseListCommand : IRequest<CreatedRequiredCourseListResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Guid> CourseIds { get; set; } = new List<Guid>();

    public class CreateRequiredCourseListCommandHandler : IRequestHandler<CreateRequiredCourseListCommand, CreatedRequiredCourseListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly RequiredCourseListBusinessRules _requiredCourseListBusinessRules;

        public CreateRequiredCourseListCommandHandler(
            IMapper mapper, 
            IRequiredCourseListRepository requiredCourseListRepository,
            IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
            ICourseRepository courseRepository,
            RequiredCourseListBusinessRules requiredCourseListBusinessRules)
        {
            _mapper = mapper;
            _requiredCourseListRepository = requiredCourseListRepository;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _courseRepository = courseRepository;
            _requiredCourseListBusinessRules = requiredCourseListBusinessRules;
        }

        public async Task<CreatedRequiredCourseListResponse> Handle(CreateRequiredCourseListCommand request, CancellationToken cancellationToken)
        {
            await _requiredCourseListBusinessRules.CoursesShouldExistWhenAddingToList(request.CourseIds, cancellationToken);

            RequiredCourseList requiredCourseList = _mapper.Map<RequiredCourseList>(request);

            // Önce RequiredCourseList'i kaydet
            await _requiredCourseListRepository.AddAsync(requiredCourseList);

            // Sonra Junction Table (RequiredCourseListCourse) kayıtlarını ekle
            if (request.CourseIds.Any())
            {
                foreach (var courseId in request.CourseIds)
                {
                    var requiredCourseListCourse = new RequiredCourseListCourse
                    {
                        RequiredCourseListId = requiredCourseList.Id,
                        CourseId = courseId
                    };
                    await _requiredCourseListCourseRepository.AddAsync(requiredCourseListCourse);
                }
            }

            // Response için Course'ları include et
            var requiredCourseListWithCourses = await _requiredCourseListRepository.GetAsync(
                predicate: rcl => rcl.Id == requiredCourseList.Id,
                include: rcl => rcl.Include(r => r.Courses),
                cancellationToken: cancellationToken
            );

            CreatedRequiredCourseListResponse response = _mapper.Map<CreatedRequiredCourseListResponse>(requiredCourseListWithCourses);
            return response;
        }
    }
}