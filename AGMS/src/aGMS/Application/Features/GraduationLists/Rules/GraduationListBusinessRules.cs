using Application.Features.GraduationLists.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.GraduationLists.Rules;

public class GraduationListBusinessRules : BaseBusinessRules
{
    private readonly IGraduationListRepository _graduationListRepository;
    private readonly ILocalizationService _localizationService;

    public GraduationListBusinessRules(IGraduationListRepository graduationListRepository, ILocalizationService localizationService)
    {
        _graduationListRepository = graduationListRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GraduationListsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GraduationListShouldExistWhenSelected(GraduationList? graduationList)
    {
        if (graduationList == null)
            await throwBusinessException(GraduationListsBusinessMessages.GraduationListNotExists);
    }

    public async Task GraduationListIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        GraduationList? graduationList = await _graduationListRepository.GetAsync(
            predicate: gl => gl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GraduationListShouldExistWhenSelected(graduationList);
    }
}