using Application.Features.TakenCourses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TakenCourses;

public class TakenCourseManager : ITakenCourseService
{
    private readonly ITakenCourseRepository _takenCourseRepository;
    private readonly TakenCourseBusinessRules _takenCourseBusinessRules;

    public TakenCourseManager(ITakenCourseRepository takenCourseRepository, TakenCourseBusinessRules takenCourseBusinessRules)
    {
        _takenCourseRepository = takenCourseRepository;
        _takenCourseBusinessRules = takenCourseBusinessRules;
    }

    public async Task<TakenCourse?> GetAsync(
        Expression<Func<TakenCourse, bool>> predicate,
        Func<IQueryable<TakenCourse>, IIncludableQueryable<TakenCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TakenCourse? takenCourse = await _takenCourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return takenCourse;
    }

    public async Task<IPaginate<TakenCourse>?> GetListAsync(
        Expression<Func<TakenCourse, bool>>? predicate = null,
        Func<IQueryable<TakenCourse>, IOrderedQueryable<TakenCourse>>? orderBy = null,
        Func<IQueryable<TakenCourse>, IIncludableQueryable<TakenCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TakenCourse> takenCourseList = await _takenCourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return takenCourseList;
    }

    public async Task<TakenCourse> AddAsync(TakenCourse takenCourse)
    {
        TakenCourse addedTakenCourse = await _takenCourseRepository.AddAsync(takenCourse);

        return addedTakenCourse;
    }

    public async Task<TakenCourse> UpdateAsync(TakenCourse takenCourse)
    {
        TakenCourse updatedTakenCourse = await _takenCourseRepository.UpdateAsync(takenCourse);

        return updatedTakenCourse;
    }

    public async Task<TakenCourse> DeleteAsync(TakenCourse takenCourse, bool permanent = false)
    {
        TakenCourse deletedTakenCourse = await _takenCourseRepository.DeleteAsync(takenCourse);

        return deletedTakenCourse;
    }
}
