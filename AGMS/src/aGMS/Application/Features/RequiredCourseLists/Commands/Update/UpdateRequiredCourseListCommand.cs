using Application.Features.RequiredCourseLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RequiredCourseLists.Commands.Update;

public class UpdateRequiredCourseListCommand : IRequest<UpdatedRequiredCourseListResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Guid> CourseIds { get; set; } = new List<Guid>();

    public class UpdateRequiredCourseListCommandHandler : IRequestHandler<UpdateRequiredCourseListCommand, UpdatedRequiredCourseListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly RequiredCourseListBusinessRules _requiredCourseListBusinessRules;

        public UpdateRequiredCourseListCommandHandler(
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

        public async Task<UpdatedRequiredCourseListResponse> Handle(UpdateRequiredCourseListCommand request, CancellationToken cancellationToken)
        {
            RequiredCourseList? requiredCourseList = await _requiredCourseListRepository.GetAsync(predicate: rcl => rcl.Id == request.Id, cancellationToken: cancellationToken);
            await _requiredCourseListBusinessRules.RequiredCourseListShouldExistWhenSelected(requiredCourseList);

            // Course'ların varlığını kontrol et
            await _requiredCourseListBusinessRules.CoursesShouldExistWhenAddingToList(request.CourseIds, cancellationToken);

            requiredCourseList = _mapper.Map(request, requiredCourseList);

            // Önce RequiredCourseList'i güncelle
            await _requiredCourseListRepository.UpdateAsync(requiredCourseList!);

            // Mevcut Junction Table kayıtlarını sil
            var existingRequiredCourseListCourses = await _requiredCourseListCourseRepository.GetListAsync(
                predicate: rclc => rclc.RequiredCourseListId == requiredCourseList.Id,
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            foreach (var existingRecord in existingRequiredCourseListCourses.Items)
            {
                await _requiredCourseListCourseRepository.DeleteAsync(existingRecord, permanent: true);
            }

            // Yeni Junction Table kayıtlarını ekle
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

            UpdatedRequiredCourseListResponse response = _mapper.Map<UpdatedRequiredCourseListResponse>(requiredCourseListWithCourses);
            return response;
        }
    }
}