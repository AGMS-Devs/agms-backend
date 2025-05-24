using Application.Features.RequiredCourseLists.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequiredCourseLists;

public class RequiredCourseListManager : IRequiredCourseListService
{
    private readonly IRequiredCourseListRepository _requiredCourseListRepository;
    private readonly RequiredCourseListBusinessRules _requiredCourseListBusinessRules;

    public RequiredCourseListManager(IRequiredCourseListRepository requiredCourseListRepository, RequiredCourseListBusinessRules requiredCourseListBusinessRules)
    {
        _requiredCourseListRepository = requiredCourseListRepository;
        _requiredCourseListBusinessRules = requiredCourseListBusinessRules;
    }

    public async Task<RequiredCourseList?> GetAsync(
        Expression<Func<RequiredCourseList, bool>> predicate,
        Func<IQueryable<RequiredCourseList>, IIncludableQueryable<RequiredCourseList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RequiredCourseList? requiredCourseList = await _requiredCourseListRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return requiredCourseList;
    }

    public async Task<IPaginate<RequiredCourseList>?> GetListAsync(
        Expression<Func<RequiredCourseList, bool>>? predicate = null,
        Func<IQueryable<RequiredCourseList>, IOrderedQueryable<RequiredCourseList>>? orderBy = null,
        Func<IQueryable<RequiredCourseList>, IIncludableQueryable<RequiredCourseList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RequiredCourseList> requiredCourseListList = await _requiredCourseListRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return requiredCourseListList;
    }

    public async Task<RequiredCourseList> AddAsync(RequiredCourseList requiredCourseList)
    {
        RequiredCourseList addedRequiredCourseList = await _requiredCourseListRepository.AddAsync(requiredCourseList);

        return addedRequiredCourseList;
    }

    public async Task<RequiredCourseList> UpdateAsync(RequiredCourseList requiredCourseList)
    {
        RequiredCourseList updatedRequiredCourseList = await _requiredCourseListRepository.UpdateAsync(requiredCourseList);

        return updatedRequiredCourseList;
    }

    public async Task<RequiredCourseList> DeleteAsync(RequiredCourseList requiredCourseList, bool permanent = false)
    {
        RequiredCourseList deletedRequiredCourseList = await _requiredCourseListRepository.DeleteAsync(requiredCourseList);

        return deletedRequiredCourseList;
    }
}
