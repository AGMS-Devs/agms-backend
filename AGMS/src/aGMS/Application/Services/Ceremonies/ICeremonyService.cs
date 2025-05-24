using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ceremonies;

public interface ICeremonyService
{
    Task<Ceremony?> GetAsync(
        Expression<Func<Ceremony, bool>> predicate,
        Func<IQueryable<Ceremony>, IIncludableQueryable<Ceremony, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ceremony>?> GetListAsync(
        Expression<Func<Ceremony, bool>>? predicate = null,
        Func<IQueryable<Ceremony>, IOrderedQueryable<Ceremony>>? orderBy = null,
        Func<IQueryable<Ceremony>, IIncludableQueryable<Ceremony, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ceremony> AddAsync(Ceremony ceremony);
    Task<Ceremony> UpdateAsync(Ceremony ceremony);
    Task<Ceremony> DeleteAsync(Ceremony ceremony, bool permanent = false);
}
