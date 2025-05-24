using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TopStudentLists;

public class TopStudentListManager : ITopStudentListService
{
    private readonly ITopStudentListRepository _topStudentListRepository;
    private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

    public TopStudentListManager(ITopStudentListRepository topStudentListRepository, TopStudentListBusinessRules topStudentListBusinessRules)
    {
        _topStudentListRepository = topStudentListRepository;
        _topStudentListBusinessRules = topStudentListBusinessRules;
    }

    public async Task<TopStudentList?> GetAsync(
        Expression<Func<TopStudentList, bool>> predicate,
        Func<IQueryable<TopStudentList>, IIncludableQueryable<TopStudentList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return topStudentList;
    }

    public async Task<IPaginate<TopStudentList>?> GetListAsync(
        Expression<Func<TopStudentList, bool>>? predicate = null,
        Func<IQueryable<TopStudentList>, IOrderedQueryable<TopStudentList>>? orderBy = null,
        Func<IQueryable<TopStudentList>, IIncludableQueryable<TopStudentList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TopStudentList> topStudentListList = await _topStudentListRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return topStudentListList;
    }

    public async Task<TopStudentList> AddAsync(TopStudentList topStudentList)
    {
        TopStudentList addedTopStudentList = await _topStudentListRepository.AddAsync(topStudentList);

        return addedTopStudentList;
    }

    public async Task<TopStudentList> UpdateAsync(TopStudentList topStudentList)
    {
        TopStudentList updatedTopStudentList = await _topStudentListRepository.UpdateAsync(topStudentList);

        return updatedTopStudentList;
    }

    public async Task<TopStudentList> DeleteAsync(TopStudentList topStudentList, bool permanent = false)
    {
        TopStudentList deletedTopStudentList = await _topStudentListRepository.DeleteAsync(topStudentList);

        return deletedTopStudentList;
    }
}
