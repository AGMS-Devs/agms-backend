using Application.Features.FacultyDeansOffices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FacultyDeansOffices.Rules;

public class FacultyDeansOfficeBusinessRules : BaseBusinessRules
{
    private readonly IFacultyDeansOfficeRepository _facultyDeansOfficeRepository;
    private readonly ILocalizationService _localizationService;

    public FacultyDeansOfficeBusinessRules(IFacultyDeansOfficeRepository facultyDeansOfficeRepository, ILocalizationService localizationService)
    {
        _facultyDeansOfficeRepository = facultyDeansOfficeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FacultyDeansOfficesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FacultyDeansOfficeShouldExistWhenSelected(FacultyDeansOffice? facultyDeansOffice)
    {
        if (facultyDeansOffice == null)
            await throwBusinessException(FacultyDeansOfficesBusinessMessages.FacultyDeansOfficeNotExists);
    }

    public async Task FacultyDeansOfficeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        FacultyDeansOffice? facultyDeansOffice = await _facultyDeansOfficeRepository.GetAsync(
            predicate: fdo => fdo.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FacultyDeansOfficeShouldExistWhenSelected(facultyDeansOffice);
    }
}