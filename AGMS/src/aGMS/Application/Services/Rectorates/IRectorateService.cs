using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Rectorates;

public interface IRectorateService
{
    Task<Rectorate?> GetAsync(
        Expression<Func<Rectorate, bool>> predicate,
        Func<IQueryable<Rectorate>, IIncludableQueryable<Rectorate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Rectorate>?> GetListAsync(
        Expression<Func<Rectorate, bool>>? predicate = null,
        Func<IQueryable<Rectorate>, IOrderedQueryable<Rectorate>>? orderBy = null,
        Func<IQueryable<Rectorate>, IIncludableQueryable<Rectorate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Rectorate> AddAsync(Rectorate rectorate);
    Task<Rectorate> UpdateAsync(Rectorate rectorate);
    Task<Rectorate> DeleteAsync(Rectorate rectorate, bool permanent = false);
}
