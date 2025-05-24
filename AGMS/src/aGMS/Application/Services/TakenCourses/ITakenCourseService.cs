using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TakenCourses;

public interface ITakenCourseService
{
    Task<TakenCourse?> GetAsync(
        Expression<Func<TakenCourse, bool>> predicate,
        Func<IQueryable<TakenCourse>, IIncludableQueryable<TakenCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TakenCourse>?> GetListAsync(
        Expression<Func<TakenCourse, bool>>? predicate = null,
        Func<IQueryable<TakenCourse>, IOrderedQueryable<TakenCourse>>? orderBy = null,
        Func<IQueryable<TakenCourse>, IIncludableQueryable<TakenCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TakenCourse> AddAsync(TakenCourse takenCourse);
    Task<TakenCourse> UpdateAsync(TakenCourse takenCourse);
    Task<TakenCourse> DeleteAsync(TakenCourse takenCourse, bool permanent = false);
}
