using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Advisors;

public interface IAdvisorService
{
    Task<Advisor?> GetAsync(
        Expression<Func<Advisor, bool>> predicate,
        Func<IQueryable<Advisor>, IIncludableQueryable<Advisor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Advisor>?> GetListAsync(
        Expression<Func<Advisor, bool>>? predicate = null,
        Func<IQueryable<Advisor>, IOrderedQueryable<Advisor>>? orderBy = null,
        Func<IQueryable<Advisor>, IIncludableQueryable<Advisor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Advisor> AddAsync(Advisor advisor);
    Task<Advisor> UpdateAsync(Advisor advisor);
    Task<Advisor> DeleteAsync(Advisor advisor, bool permanent = false);
}
