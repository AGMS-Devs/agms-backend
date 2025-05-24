using Application.Features.Ceremonies.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Ceremonies.Rules;

public class CeremonyBusinessRules : BaseBusinessRules
{
    private readonly ICeremonyRepository _ceremonyRepository;
    private readonly IStudentAffairRepository _studentAffairRepository;
    private readonly ILocalizationService _localizationService;

    public CeremonyBusinessRules(ICeremonyRepository ceremonyRepository, IStudentAffairRepository studentAffairRepository, ILocalizationService localizationService)
    {
        _ceremonyRepository = ceremonyRepository;
        _studentAffairRepository = studentAffairRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CeremoniesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CeremonyShouldExistWhenSelected(Ceremony? ceremony)
    {
        if (ceremony == null)
            await throwBusinessException(CeremoniesBusinessMessages.CeremonyNotExists);
    }

    public async Task CeremonyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Ceremony? ceremony = await _ceremonyRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CeremonyShouldExistWhenSelected(ceremony);
    }

    public async Task StudentAffairShouldExistWhenSelected(Guid studentAffairId, CancellationToken cancellationToken)
    {
        StudentAffair? studentAffair = await _studentAffairRepository.GetAsync(
            predicate: sa => sa.Id == studentAffairId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (studentAffair == null)
            await throwBusinessException(CeremoniesBusinessMessages.StudentAffairNotExists);
    }
}