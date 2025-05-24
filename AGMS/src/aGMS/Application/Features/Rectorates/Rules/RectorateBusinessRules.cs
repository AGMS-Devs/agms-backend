using Application.Features.Rectorates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Rectorates.Rules;

public class RectorateBusinessRules : BaseBusinessRules
{
    private readonly IRectorateRepository _rectorateRepository;
    private readonly ILocalizationService _localizationService;

    public RectorateBusinessRules(IRectorateRepository rectorateRepository, ILocalizationService localizationService)
    {
        _rectorateRepository = rectorateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RectoratesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RectorateShouldExistWhenSelected(Rectorate? rectorate)
    {
        if (rectorate == null)
            await throwBusinessException(RectoratesBusinessMessages.RectorateNotExists);
    }

    public async Task RectorateIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Rectorate? rectorate = await _rectorateRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RectorateShouldExistWhenSelected(rectorate);
    }
}