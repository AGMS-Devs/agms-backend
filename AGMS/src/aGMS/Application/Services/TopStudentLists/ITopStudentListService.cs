using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TopStudentLists;

public interface ITopStudentListService
{
    Task<TopStudentList?> GetAsync(
        Expression<Func<TopStudentList, bool>> predicate,
        Func<IQueryable<TopStudentList>, IIncludableQueryable<TopStudentList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TopStudentList>?> GetListAsync(
        Expression<Func<TopStudentList, bool>>? predicate = null,
        Func<IQueryable<TopStudentList>, IOrderedQueryable<TopStudentList>>? orderBy = null,
        Func<IQueryable<TopStudentList>, IIncludableQueryable<TopStudentList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TopStudentList> AddAsync(TopStudentList topStudentList);
    Task<TopStudentList> UpdateAsync(TopStudentList topStudentList);
    Task<TopStudentList> DeleteAsync(TopStudentList topStudentList, bool permanent = false);
}
