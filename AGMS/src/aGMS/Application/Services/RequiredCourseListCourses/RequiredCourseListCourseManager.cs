using Application.Features.RequiredCourseListCourses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequiredCourseListCourses;

public class RequiredCourseListCourseManager : IRequiredCourseListCourseService
{
    private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
    private readonly RequiredCourseListCourseBusinessRules _requiredCourseListCourseBusinessRules;

    public RequiredCourseListCourseManager(IRequiredCourseListCourseRepository requiredCourseListCourseRepository, RequiredCourseListCourseBusinessRules requiredCourseListCourseBusinessRules)
    {
        _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
        _requiredCourseListCourseBusinessRules = requiredCourseListCourseBusinessRules;
    }

    public async Task<RequiredCourseListCourse?> GetAsync(
        Expression<Func<RequiredCourseListCourse, bool>> predicate,
        Func<IQueryable<RequiredCourseListCourse>, IIncludableQueryable<RequiredCourseListCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RequiredCourseListCourse? requiredCourseListCourse = await _requiredCourseListCourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return requiredCourseListCourse;
    }

    public async Task<IPaginate<RequiredCourseListCourse>?> GetListAsync(
        Expression<Func<RequiredCourseListCourse, bool>>? predicate = null,
        Func<IQueryable<RequiredCourseListCourse>, IOrderedQueryable<RequiredCourseListCourse>>? orderBy = null,
        Func<IQueryable<RequiredCourseListCourse>, IIncludableQueryable<RequiredCourseListCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RequiredCourseListCourse> requiredCourseListCourseList = await _requiredCourseListCourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return requiredCourseListCourseList;
    }

    public async Task<RequiredCourseListCourse> AddAsync(RequiredCourseListCourse requiredCourseListCourse)
    {
        RequiredCourseListCourse addedRequiredCourseListCourse = await _requiredCourseListCourseRepository.AddAsync(requiredCourseListCourse);

        return addedRequiredCourseListCourse;
    }

    public async Task<RequiredCourseListCourse> UpdateAsync(RequiredCourseListCourse requiredCourseListCourse)
    {
        RequiredCourseListCourse updatedRequiredCourseListCourse = await _requiredCourseListCourseRepository.UpdateAsync(requiredCourseListCourse);

        return updatedRequiredCourseListCourse;
    }

    public async Task<RequiredCourseListCourse> DeleteAsync(RequiredCourseListCourse requiredCourseListCourse, bool permanent = false)
    {
        RequiredCourseListCourse deletedRequiredCourseListCourse = await _requiredCourseListCourseRepository.DeleteAsync(requiredCourseListCourse);

        return deletedRequiredCourseListCourse;
    }
}
