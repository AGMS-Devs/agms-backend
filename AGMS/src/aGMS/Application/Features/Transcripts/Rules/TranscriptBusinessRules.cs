using Application.Features.Transcripts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Transcripts.Rules;

public class TranscriptBusinessRules : BaseBusinessRules
{
    private readonly ITranscriptRepository _transcriptRepository;
    private readonly ILocalizationService _localizationService;

    public TranscriptBusinessRules(ITranscriptRepository transcriptRepository, ILocalizationService localizationService)
    {
        _transcriptRepository = transcriptRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TranscriptsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TranscriptShouldExistWhenSelected(Transcript? transcript)
    {
        if (transcript == null)
            await throwBusinessException(TranscriptsBusinessMessages.TranscriptNotExists);
    }

    public async Task TranscriptIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Transcript? transcript = await _transcriptRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TranscriptShouldExistWhenSelected(transcript);
    }
}