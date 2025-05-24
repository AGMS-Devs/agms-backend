using Application.Features.Courses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Courses.Rules;

public class CourseBusinessRules : BaseBusinessRules
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILocalizationService _localizationService;
    private readonly ITakenCourseRepository _takenCourseRepository;
    private readonly IRequiredCourseListRepository _requiredCourseListRepository;

    public CourseBusinessRules(ICourseRepository courseRepository, 
                             ILocalizationService localizationService,
                             ITakenCourseRepository takenCourseRepository,
                             IRequiredCourseListRepository requiredCourseListRepository)
    {
        _courseRepository = courseRepository;
        _localizationService = localizationService;
        _takenCourseRepository = takenCourseRepository;
        _requiredCourseListRepository = requiredCourseListRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CoursesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CourseShouldExistWhenSelected(Course? course)
    {
        if (course == null)
            await throwBusinessException(CoursesBusinessMessages.CourseNotExists);
    }

    public async Task CourseShouldNotBeUsedWhenDeleting(Course course)
    {
        bool isUsedInTakenCourse = await _takenCourseRepository.AnyAsync(tc => tc.CourseId == course.Id);
        if (isUsedInTakenCourse)
            throw new BusinessException("Bu ders öğrenciler tarafından alınmış durumda, silinemez.");

        bool isUsedInRequiredCourseList = await _requiredCourseListRepository.AnyAsync(rcl => rcl.Courses.Any(c => c.Id == course.Id));
        if (isUsedInRequiredCourseList)
            throw new BusinessException("Bu ders zorunlu ders listelerinde kullanılıyor, silinemez.");
    }

    public async Task CourseIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Course? course = await _courseRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseShouldExistWhenSelected(course);
    }
}