using Application.Features.GraduationLists.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GraduationLists;

public class GraduationListManager : IGraduationListService
{
    private readonly IGraduationListRepository _graduationListRepository;
    private readonly GraduationListBusinessRules _graduationListBusinessRules;

    public GraduationListManager(IGraduationListRepository graduationListRepository, GraduationListBusinessRules graduationListBusinessRules)
    {
        _graduationListRepository = graduationListRepository;
        _graduationListBusinessRules = graduationListBusinessRules;
    }

    public async Task<GraduationList?> GetAsync(
        Expression<Func<GraduationList, bool>> predicate,
        Func<IQueryable<GraduationList>, IIncludableQueryable<GraduationList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        GraduationList? graduationList = await _graduationListRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return graduationList;
    }

    public async Task<IPaginate<GraduationList>?> GetListAsync(
        Expression<Func<GraduationList, bool>>? predicate = null,
        Func<IQueryable<GraduationList>, IOrderedQueryable<GraduationList>>? orderBy = null,
        Func<IQueryable<GraduationList>, IIncludableQueryable<GraduationList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<GraduationList> graduationListList = await _graduationListRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return graduationListList;
    }

    public async Task<GraduationList> AddAsync(GraduationList graduationList)
    {
        GraduationList addedGraduationList = await _graduationListRepository.AddAsync(graduationList);

        return addedGraduationList;
    }

    public async Task<GraduationList> UpdateAsync(GraduationList graduationList)
    {
        GraduationList updatedGraduationList = await _graduationListRepository.UpdateAsync(graduationList);

        return updatedGraduationList;
    }

    public async Task<GraduationList> DeleteAsync(GraduationList graduationList, bool permanent = false)
    {
        GraduationList deletedGraduationList = await _graduationListRepository.DeleteAsync(graduationList);

        return deletedGraduationList;
    }
}
