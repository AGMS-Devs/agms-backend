using Application.Features.TakenCourses.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.TakenCourses.Rules;

public class TakenCourseBusinessRules : BaseBusinessRules
{
    private readonly ITakenCourseRepository _takenCourseRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ILocalizationService _localizationService;

    public TakenCourseBusinessRules(
        ITakenCourseRepository takenCourseRepository,
        ICourseRepository courseRepository,
        IStudentRepository studentRepository,
        ILocalizationService localizationService)
    {
        _takenCourseRepository = takenCourseRepository;
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TakenCoursesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CourseShouldExistWhenCreatingTakenCourse(Guid courseId, CancellationToken cancellationToken)
    {
        Course? course = await _courseRepository.GetAsync(
            predicate: c => c.Id == courseId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (course == null)
            throw new BusinessException("Ders bulunamadı.");
    }

    public async Task StudentShouldExistWhenCreatingTakenCourse(Guid studentId, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetAsync(
            predicate: s => s.Id == studentId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (student == null)
            throw new BusinessException("Öğrenci bulunamadı.");
    }

    public async Task StudentShouldNotHaveTakenCourse(Guid studentId, Guid courseId, CancellationToken cancellationToken)
    {
        bool hasTakenCourse = await _takenCourseRepository.AnyAsync(
            predicate: tc => tc.StudentId == studentId && tc.CourseId == courseId,
            cancellationToken: cancellationToken
        );

        if (hasTakenCourse)
            throw new BusinessException("Öğrenci bu dersi zaten almış.");
    }

    public async Task TakenCourseShouldExistWhenSelected(TakenCourse? takenCourse)
    {
        if (takenCourse == null)
            await throwBusinessException(TakenCoursesBusinessMessages.TakenCourseNotExists);
    }

    public async Task TakenCourseIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TakenCourse? takenCourse = await _takenCourseRepository.GetAsync(
            predicate: tc => tc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TakenCourseShouldExistWhenSelected(takenCourse);
    }

    public Task StudentShouldHaveAtLeastOneTakenCourse(ICollection<TakenCourse> takenCourses)
    {
        if (!takenCourses.Any())
            throw new BusinessException(TakenCoursesBusinessMessages.StudentHasNoTakenCourses);
        return Task.CompletedTask;
    }
}