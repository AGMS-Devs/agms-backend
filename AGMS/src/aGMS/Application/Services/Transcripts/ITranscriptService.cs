using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Transcripts;

public interface ITranscriptService
{
    Task<Transcript?> GetAsync(
        Expression<Func<Transcript, bool>> predicate,
        Func<IQueryable<Transcript>, IIncludableQueryable<Transcript, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Transcript>?> GetListAsync(
        Expression<Func<Transcript, bool>>? predicate = null,
        Func<IQueryable<Transcript>, IOrderedQueryable<Transcript>>? orderBy = null,
        Func<IQueryable<Transcript>, IIncludableQueryable<Transcript, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Transcript> AddAsync(Transcript transcript);
    Task<Transcript> UpdateAsync(Transcript transcript);
    Task<Transcript> DeleteAsync(Transcript transcript, bool permanent = false);
}
