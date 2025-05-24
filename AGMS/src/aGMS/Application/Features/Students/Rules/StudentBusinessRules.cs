using Application.Features.Students.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;


namespace Application.Features.Students.Rules;

public class StudentBusinessRules : BaseBusinessRules
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILocalizationService _localizationService;
    private readonly ITakenCourseRepository _takenCourseRepository;
    private readonly IRequiredCourseListRepository _requiredCourseListRepository;

    public StudentBusinessRules(
        IStudentRepository studentRepository, 
        ILocalizationService localizationService,
        ITakenCourseRepository takenCourseRepository,
        IRequiredCourseListRepository requiredCourseListRepository)
    {
        _studentRepository = studentRepository;
        _localizationService = localizationService;
        _takenCourseRepository = takenCourseRepository;
        _requiredCourseListRepository = requiredCourseListRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StudentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StudentShouldExistWhenSelected(Student? student)
    {
        if (student == null)
            await throwBusinessException(StudentsBusinessMessages.StudentNotExists);
    }

    public async Task StudentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentShouldExistWhenSelected(student);
    }

    public async Task StudentNumberShouldBeUnique(string studentNumber)
    {
        var student = await _studentRepository.GetAsync(
            predicate: s => s.StudentNumber == studentNumber,
            cancellationToken: CancellationToken.None
        );

        if (student != null)
        {
            throw new BusinessException("Bu öğrenci numarası zaten kullanılıyor.");
        }
    }

    public async Task StudentShouldNotHaveAnyTakenCoursesWhenDeleting(Guid studentId, CancellationToken cancellationToken)
    {
        bool hasTakenCourses = await _takenCourseRepository.AnyAsync(
            predicate: tc => tc.StudentId == studentId,
            cancellationToken: cancellationToken
        );

        if (hasTakenCourses)
            throw new BusinessException("Öğrencinin aldığı dersler var, silinemez.");
    }

}