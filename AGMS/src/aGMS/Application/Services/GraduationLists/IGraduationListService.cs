using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GraduationLists;

public interface IGraduationListService
{
    Task<GraduationList?> GetAsync(
        Expression<Func<GraduationList, bool>> predicate,
        Func<IQueryable<GraduationList>, IIncludableQueryable<GraduationList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<GraduationList>?> GetListAsync(
        Expression<Func<GraduationList, bool>>? predicate = null,
        Func<IQueryable<GraduationList>, IOrderedQueryable<GraduationList>>? orderBy = null,
        Func<IQueryable<GraduationList>, IIncludableQueryable<GraduationList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<GraduationList> AddAsync(GraduationList graduationList);
    Task<GraduationList> UpdateAsync(GraduationList graduationList);
    Task<GraduationList> DeleteAsync(GraduationList graduationList, bool permanent = false);
}
