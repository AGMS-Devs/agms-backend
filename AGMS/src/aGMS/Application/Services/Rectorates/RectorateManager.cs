using Application.Features.Rectorates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Rectorates;

public class RectorateManager : IRectorateService
{
    private readonly IRectorateRepository _rectorateRepository;
    private readonly RectorateBusinessRules _rectorateBusinessRules;

    public RectorateManager(IRectorateRepository rectorateRepository, RectorateBusinessRules rectorateBusinessRules)
    {
        _rectorateRepository = rectorateRepository;
        _rectorateBusinessRules = rectorateBusinessRules;
    }

    public async Task<Rectorate?> GetAsync(
        Expression<Func<Rectorate, bool>> predicate,
        Func<IQueryable<Rectorate>, IIncludableQueryable<Rectorate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Rectorate? rectorate = await _rectorateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rectorate;
    }

    public async Task<IPaginate<Rectorate>?> GetListAsync(
        Expression<Func<Rectorate, bool>>? predicate = null,
        Func<IQueryable<Rectorate>, IOrderedQueryable<Rectorate>>? orderBy = null,
        Func<IQueryable<Rectorate>, IIncludableQueryable<Rectorate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Rectorate> rectorateList = await _rectorateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return rectorateList;
    }

    public async Task<Rectorate> AddAsync(Rectorate rectorate)
    {
        Rectorate addedRectorate = await _rectorateRepository.AddAsync(rectorate);

        return addedRectorate;
    }

    public async Task<Rectorate> UpdateAsync(Rectorate rectorate)
    {
        Rectorate updatedRectorate = await _rectorateRepository.UpdateAsync(rectorate);

        return updatedRectorate;
    }

    public async Task<Rectorate> DeleteAsync(Rectorate rectorate, bool permanent = false)
    {
        Rectorate deletedRectorate = await _rectorateRepository.DeleteAsync(rectorate);

        return deletedRectorate;
    }
}
