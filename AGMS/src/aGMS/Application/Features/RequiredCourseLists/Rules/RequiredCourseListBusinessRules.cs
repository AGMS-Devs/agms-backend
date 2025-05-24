using Application.Features.RequiredCourseLists.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Services.Repositories;

namespace Application.Features.RequiredCourseLists.Rules;

public class RequiredCourseListBusinessRules : BaseBusinessRules
{
    private readonly IRequiredCourseListRepository _requiredCourseListRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;

    public RequiredCourseListBusinessRules(
        IRequiredCourseListRepository requiredCourseListRepository,
        ILocalizationService localizationService,
        IStudentRepository studentRepository,
        ICourseRepository courseRepository)
    {
        _requiredCourseListRepository = requiredCourseListRepository;
        _localizationService = localizationService;
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RequiredCourseListsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RequiredCourseListShouldExistWhenSelected(RequiredCourseList? requiredCourseList)
    {
        if (requiredCourseList == null)
            await throwBusinessException(RequiredCourseListsBusinessMessages.RequiredCourseListNotExists);
    }

    public async Task RequiredCourseListIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RequiredCourseList? requiredCourseList = await _requiredCourseListRepository.GetAsync(
            predicate: rcl => rcl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequiredCourseListShouldExistWhenSelected(requiredCourseList);
    }

    public async Task StudentShouldExistWhenCreatingRequiredCourseList(Guid studentId, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetAsync(
            predicate: s => s.Id == studentId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (student == null)
            throw new BusinessException("Öğrenci bulunamadı.");
    }

    public async Task StudentShouldNotHaveRequiredCourseList(Guid studentId, CancellationToken cancellationToken)
    {
        bool hasRequiredCourseList = await _requiredCourseListRepository.AnyAsync(
            predicate: rcl => rcl.Students.Any(s => s.Id == studentId),
            cancellationToken: cancellationToken
        );

        if (hasRequiredCourseList)
            throw new BusinessException("Öğrencinin zaten bir zorunlu ders listesi var.");
    }

    public async Task CoursesShouldExistWhenAddingToList(ICollection<Guid> courseIds, CancellationToken cancellationToken)
    {
        foreach (var courseId in courseIds)
        {
            bool exists = await _courseRepository.AnyAsync(
                predicate: c => c.Id == courseId,
                cancellationToken: cancellationToken
            );

            if (!exists)
                throw new BusinessException($"ID'si {courseId} olan ders bulunamadı.");
        }
    }
}