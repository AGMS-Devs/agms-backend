using Application.Features.Advisors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Advisors.Rules;

public class AdvisorBusinessRules : BaseBusinessRules
{
    private readonly IAdvisorRepository _advisorRepository;
    private readonly ILocalizationService _localizationService;

    public AdvisorBusinessRules(IAdvisorRepository advisorRepository, ILocalizationService localizationService)
    {
        _advisorRepository = advisorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdvisorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdvisorShouldExistWhenSelected(Advisor? advisor)
    {
        if (advisor == null)
            await throwBusinessException(AdvisorsBusinessMessages.AdvisorNotExists);
    }

    public async Task AdvisorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Advisor? advisor = await _advisorRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdvisorShouldExistWhenSelected(advisor);
    }
}