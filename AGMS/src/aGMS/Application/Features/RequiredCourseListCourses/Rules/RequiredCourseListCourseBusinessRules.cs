using Application.Features.RequiredCourseListCourses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RequiredCourseListCourses.Rules;

public class RequiredCourseListCourseBusinessRules : BaseBusinessRules
{
    private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
    private readonly ILocalizationService _localizationService;

    public RequiredCourseListCourseBusinessRules(IRequiredCourseListCourseRepository requiredCourseListCourseRepository, ILocalizationService localizationService)
    {
        _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RequiredCourseListCoursesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RequiredCourseListCourseShouldExistWhenSelected(RequiredCourseListCourse? requiredCourseListCourse)
    {
        if (requiredCourseListCourse == null)
            await throwBusinessException(RequiredCourseListCoursesBusinessMessages.RequiredCourseListCourseNotExists);
    }

    public async Task RequiredCourseListCourseIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RequiredCourseListCourse? requiredCourseListCourse = await _requiredCourseListCourseRepository.GetAsync(
            predicate: rclc => rclc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequiredCourseListCourseShouldExistWhenSelected(requiredCourseListCourse);
    }
}