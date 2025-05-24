using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequiredCourseLists;

public interface IRequiredCourseListService
{
    Task<RequiredCourseList?> GetAsync(
        Expression<Func<RequiredCourseList, bool>> predicate,
        Func<IQueryable<RequiredCourseList>, IIncludableQueryable<RequiredCourseList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RequiredCourseList>?> GetListAsync(
        Expression<Func<RequiredCourseList, bool>>? predicate = null,
        Func<IQueryable<RequiredCourseList>, IOrderedQueryable<RequiredCourseList>>? orderBy = null,
        Func<IQueryable<RequiredCourseList>, IIncludableQueryable<RequiredCourseList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RequiredCourseList> AddAsync(RequiredCourseList requiredCourseList);
    Task<RequiredCourseList> UpdateAsync(RequiredCourseList requiredCourseList);
    Task<RequiredCourseList> DeleteAsync(RequiredCourseList requiredCourseList, bool permanent = false);
}
