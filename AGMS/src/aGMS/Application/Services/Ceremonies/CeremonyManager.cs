using Application.Features.Ceremonies.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ceremonies;

public class CeremonyManager : ICeremonyService
{
    private readonly ICeremonyRepository _ceremonyRepository;
    private readonly CeremonyBusinessRules _ceremonyBusinessRules;

    public CeremonyManager(ICeremonyRepository ceremonyRepository, CeremonyBusinessRules ceremonyBusinessRules)
    {
        _ceremonyRepository = ceremonyRepository;
        _ceremonyBusinessRules = ceremonyBusinessRules;
    }

    public async Task<Ceremony?> GetAsync(
        Expression<Func<Ceremony, bool>> predicate,
        Func<IQueryable<Ceremony>, IIncludableQueryable<Ceremony, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ceremony? ceremony = await _ceremonyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ceremony;
    }

    public async Task<IPaginate<Ceremony>?> GetListAsync(
        Expression<Func<Ceremony, bool>>? predicate = null,
        Func<IQueryable<Ceremony>, IOrderedQueryable<Ceremony>>? orderBy = null,
        Func<IQueryable<Ceremony>, IIncludableQueryable<Ceremony, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ceremony> ceremonyList = await _ceremonyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ceremonyList;
    }

    public async Task<Ceremony> AddAsync(Ceremony ceremony)
    {
        Ceremony addedCeremony = await _ceremonyRepository.AddAsync(ceremony);

        return addedCeremony;
    }

    public async Task<Ceremony> UpdateAsync(Ceremony ceremony)
    {
        Ceremony updatedCeremony = await _ceremonyRepository.UpdateAsync(ceremony);

        return updatedCeremony;
    }

    public async Task<Ceremony> DeleteAsync(Ceremony ceremony, bool permanent = false)
    {
        Ceremony deletedCeremony = await _ceremonyRepository.DeleteAsync(ceremony);

        return deletedCeremony;
    }
}
