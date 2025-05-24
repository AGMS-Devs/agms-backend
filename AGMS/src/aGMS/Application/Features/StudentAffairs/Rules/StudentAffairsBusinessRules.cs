using Application.Features.StudentAffairs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.StudentAffairs.Rules;

public class StudentAffairsBusinessRules : BaseBusinessRules
{
    private readonly IStudentAffairRepository _studentAffairRepository;
    private readonly ILocalizationService _localizationService;

    public StudentAffairsBusinessRules(IStudentAffairRepository studentAffairRepository, ILocalizationService localizationService)
    {
        _studentAffairRepository = studentAffairRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StudentAffairsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StudentAffairShouldExistWhenSelected(StudentAffair? studentAffair)
    {
        if (studentAffair == null)
            await throwBusinessException(StudentAffairsBusinessMessages.StudentAffairNotExists);
    }

    public async Task StudentAffairIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentAffair? studentAffair = await _studentAffairRepository.GetAsync(
            predicate: sa => sa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentAffairShouldExistWhenSelected(studentAffair);
    }
}