using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequiredCourseListCourses;

public interface IRequiredCourseListCourseService
{
    Task<RequiredCourseListCourse?> GetAsync(
        Expression<Func<RequiredCourseListCourse, bool>> predicate,
        Func<IQueryable<RequiredCourseListCourse>, IIncludableQueryable<RequiredCourseListCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RequiredCourseListCourse>?> GetListAsync(
        Expression<Func<RequiredCourseListCourse, bool>>? predicate = null,
        Func<IQueryable<RequiredCourseListCourse>, IOrderedQueryable<RequiredCourseListCourse>>? orderBy = null,
        Func<IQueryable<RequiredCourseListCourse>, IIncludableQueryable<RequiredCourseListCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RequiredCourseListCourse> AddAsync(RequiredCourseListCourse requiredCourseListCourse);
    Task<RequiredCourseListCourse> UpdateAsync(RequiredCourseListCourse requiredCourseListCourse);
    Task<RequiredCourseListCourse> DeleteAsync(RequiredCourseListCourse requiredCourseListCourse, bool permanent = false);
}
