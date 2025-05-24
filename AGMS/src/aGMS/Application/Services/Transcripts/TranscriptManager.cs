using Application.Features.Transcripts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Transcripts;

public class TranscriptManager : ITranscriptService
{
    private readonly ITranscriptRepository _transcriptRepository;
    private readonly TranscriptBusinessRules _transcriptBusinessRules;

    public TranscriptManager(ITranscriptRepository transcriptRepository, TranscriptBusinessRules transcriptBusinessRules)
    {
        _transcriptRepository = transcriptRepository;
        _transcriptBusinessRules = transcriptBusinessRules;
    }

    public async Task<Transcript?> GetAsync(
        Expression<Func<Transcript, bool>> predicate,
        Func<IQueryable<Transcript>, IIncludableQueryable<Transcript, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Transcript? transcript = await _transcriptRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return transcript;
    }

    public async Task<IPaginate<Transcript>?> GetListAsync(
        Expression<Func<Transcript, bool>>? predicate = null,
        Func<IQueryable<Transcript>, IOrderedQueryable<Transcript>>? orderBy = null,
        Func<IQueryable<Transcript>, IIncludableQueryable<Transcript, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Transcript> transcriptList = await _transcriptRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return transcriptList;
    }

    public async Task<Transcript> AddAsync(Transcript transcript)
    {
        Transcript addedTranscript = await _transcriptRepository.AddAsync(transcript);

        return addedTranscript;
    }

    public async Task<Transcript> UpdateAsync(Transcript transcript)
    {
        Transcript updatedTranscript = await _transcriptRepository.UpdateAsync(transcript);

        return updatedTranscript;
    }

    public async Task<Transcript> DeleteAsync(Transcript transcript, bool permanent = false)
    {
        Transcript deletedTranscript = await _transcriptRepository.DeleteAsync(transcript);

        return deletedTranscript;
    }
}
